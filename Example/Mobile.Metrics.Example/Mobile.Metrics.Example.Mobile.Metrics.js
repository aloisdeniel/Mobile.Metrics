var defaultActiveColors = ["#3fB618","#2780E3","#9954BB","#FF7518","#FF0039"];

// Utils ----------->

(function ($, sr) {

    // debouncing function from John Hann
    // http://unscriptable.com/index.php/2009/03/20/debouncing-javascript-methods/
    var debounce = function (func, threshold, execAsap) {
        var timeout;

        return function debounced() {
            var obj = this, args = arguments;
            function delayed() {
                if (!execAsap)
                    func.apply(obj, args);
                timeout = null;
            };

            if (timeout)
                clearTimeout(timeout);
            else if (execAsap)
                func.apply(obj, args);

            timeout = setTimeout(delayed, threshold || 100);
        };
    }
    // smartresize 
    jQuery.fn[sr] = function (fn) { return fn ? this.bind('resize', debounce(fn)) : this.trigger(sr); };

})(jQuery, 'smartresize');

function sharedStart(array) {
    var A = array.concat().sort(),
    a1 = A[0], a2 = A[A.length - 1], L = a1.length, i = 0;
    while (i < L && a1.charAt(i) === a2.charAt(i)) i++;
    return a1.substring(0, i);
}

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function getFilename(path) {
    var li = path.lastIndexOf('/');
    if (li < 0) { li = path.lastIndexOf('\\'); }
    return path.substring(li + 1);
}

function findProjectAndFilename(data, filepath) {

    for (var p in data.Metrics.Projects) {
        var project = data.Metrics.Projects[p];

        for (var f in project.Files) {
            var file = project.Files[f];

            if (file.File == filepath) {
                return {
                    project: project.Name,
                    name: getFilename(filepath)
                };
            }
        }
    }

    return { file: getFilename(filepath) };
}


function main() {

    // Get section from query string

    var sectionQuery = getParameterByName('section');
    if (!sectionQuery) sectionQuery = "index";

    // Adding simplified project names

    var projectNames = [];

    for (var p in report.Metrics.Projects) {
        var project = report.Metrics.Projects[p];
        projectNames.push(project.Name);
    }

    var commonProjectNamePrefix = sharedStart(projectNames);

    if (commonProjectNamePrefix) {
        for (var p in report.Metrics.Projects) {
            var project = report.Metrics.Projects[p];
            project.SimplifiedName = project.Name.replace(commonProjectNamePrefix, '');
        }
    }

    // Create view
    renderMenu(report, sectionQuery);
    renderContent(report, sectionQuery);
}


// Menu ---->

function renderMenu(data, section) {

    var viewModel = {
        categories: [
          {
              id: "solution",
              title: "Solution",
              sections: [
                {
                    id: "index",
                    glyph: "th",
                    title: "Vue d'ensemble"
                },
                {
                    id: "warnings",
                    glyph: "alert",
                    title: "Alertes"
                },
                {
                    id: "duplication",
                    glyph: "save-file",
                    title: "Duplication"
                }
              ]
          },
          {
              id: "projects",
              title: "Projets",
              sections: []
          }
        ]
    };

    viewModel.categories[0].sections[1].badge = data.Warnings.length;
    viewModel.categories[0].sections[2].badge = data.Duplicates.length;

    for (var p in data.Metrics.Projects) {
        var project = data.Metrics.Projects[p];

        var id = 'project-' + p;

        var sectionVm = {
            id: id,
            glyph: "folder-close",
            title: project.SimplifiedName
        }

        viewModel.categories[1].sections.push(sectionVm);
    }


    // Updating selected section
    var selectedCategory = viewModel.categories[0];
    var selectedSection = selectedCategory.sections[0];
    for (var m in viewModel.categories) {
        var category = viewModel.categories[m];
        for (var s in category.sections) {
            var sect = category.sections[s];
            var sectionVm = sect;
            sectionVm.selected = (sectionVm.id === section);
            if (sectionVm.selected) {
                selectedCategory = category;
                selectedSection = sect;
            }
        }
    }

    // Rendering view

    var template = $('#templ_menu').html();
    Mustache.parse(template);
    var rendered = Mustache.render(template, viewModel);
    $('.sidebar').html(rendered);

    // Update breadcrumb
    $('.breadcrumb').append("<li>" + selectedCategory.title + "</li>");
    $('.breadcrumb').append("<li>" + selectedSection.title + "</li>");

}

// Content ---->

function renderContent(data, section) {

    if (section === "warnings") {
        renderContentWarnings(data);
    }
    else if (section === "duplication") {
        renderContentDuplication(data);
    }
    else if (section.indexOf("project-") === 0) {
        var index = section.replace("project-", "");
        renderContentProject(data,index);
    }
    else {
        $(window).smartresize(function () { renderContentIndex(data); });
        renderContentIndex(data);
    }
}

// Index ---->

function renderContentIndex(data) {

    var viewModel = {
        metrics: []
    };

    // Repartition & Complexity

    var repartitionVm = {
        title: "Proportion de code par projet",
        glyph: "sort-by-attributes-alt",
        id: "repartition",
        graph: "donut",
        label: "Lignes",
        data: []
    };

    var linesVm = {
        title: "Lignes de code",
        glyph: "sort-by-attributes-alt",
        id: "lines",
        graph: "bars",
        xkey: 'project',
        ykeys: ['code', 'layout', 'comments'],
        labels: ['Code', 'Layout', 'Commentaires'],
        data: []
    };

    var complexityVm = {
        title: "Complexité par projet",
        glyph: "fire",
        id: "complexity",
        graph: "bars",
        xkey: 'project',
        ykeys: ['value'],
        labels: ['Complexity'],
        data: []
    };

    var filesVm = {
        title: "Fichiers par projet",
        glyph: "folder-open",
        id: "files",
        graph: "bars",
        xkey: 'project',
        ykeys: ['code', 'layout', 'assets'],
        labels: ['Code', 'Layout', 'Assets'],
        data: []
    };

    var sizesVm = {
        title: "Poids des ressources par projet",
        glyph: "scale",
        id: "sizes",
        graph: "donut",
        label: "Taille (ko)",
        data: []
    };

    var declarationsVm = {
        title: "Déclarations par projet",
        glyph: "th-list",
        id: "declarations",
        graph: "bars",
        xkey: 'project',
        ykeys: ['types', 'members', 'methods'],
        labels: ['Types', 'Membres', 'Méthodes'],
        data: []
    };

    for (var p in data.Metrics.Projects) {
        var project = data.Metrics.Projects[p];

        repartitionVm.data.push({
            label: project.SimplifiedName,
            value: project.FilesTotal.LinesOfCode
        });

        complexityVm.data.push({
            project: project.SimplifiedName,
            value: project.FilesTotal.MethodsTotal.CyclomaticComplexity
        });

        declarationsVm.data.push({
            project: project.SimplifiedName,
            types: project.FilesTotal.TypeDeclarations,
            members: project.FilesTotal.MemberDeclarations,
            methods: project.FilesTotal.MethodDeclarations
        });

        var lineVm = {
            project: project.SimplifiedName,
            code: 0,
            comments: 0,
            layout: 0
        };

        var fileVm = {
            project: project.SimplifiedName,
            code: 0,
            layout: 0,
            assets: 0
        };

        var sizeVm = {
            label: project.SimplifiedName,
            value: 0
        };

        for (var f in project.Files) {
            var file = project.Files[f];

            lineVm.comments += file.LinesOfComments;

            if ($.inArray("Code", file.Categories) >= 0) {
                lineVm.code += file.LinesOfCode;
                fileVm.code++;
            }
            if ($.inArray("Layout", file.Categories) >= 0) {
                lineVm.layout += file.LinesOfCode;
                fileVm.layout++;
            }
            if ($.inArray("Assets", file.Categories) >= 0) {
                fileVm.assets++;
                sizeVm.value += file.Size;
            }
        }

        sizeVm.value /= 1024; // Kb
        sizeVm.value = sizeVm.value.toFixed(1);

        sizesVm.data.push(sizeVm);
        filesVm.data.push(fileVm);
        linesVm.data.push(lineVm);
    }

    viewModel.metrics.push(repartitionVm);
    viewModel.metrics.push(linesVm);
    viewModel.metrics.push(complexityVm);
    viewModel.metrics.push(declarationsVm);
    viewModel.metrics.push(filesVm);
    viewModel.metrics.push(sizesVm);

    var width = (data.Metrics.Projects.length < 5) ? 6 : 12;
    for (var m in viewModel.metrics) {
        viewModel.metrics[m].width = width;
    }

    // Rendering view

    var template = $('#templ_index').html();
    Mustache.parse(template);
    var rendered = Mustache.render(template, viewModel);
    $('#content-items').html(rendered);

    // Rendering graphes
    for (var m in viewModel.metrics) {
        var metrics = viewModel.metrics[m];
        renderGraph(metrics);
    }
}

function renderGraph(graph, colors) {

    var activeColors = colors;

    if (!activeColors) {
        activeColors = defaultActiveColors;
    }

    if (graph.graph === "donut") {
        new Morris.Donut({
            element: graph.id + "-graph",
            data: graph.data,
            colors: activeColors
        });
    }
    else if (graph.graph === "bars") {
        new Morris.Bar({
            stacked: true,
            element: graph.id + "-graph",
            data: graph.data,
            xkey: graph.xkey,
            ykeys: graph.ykeys,
            labels: graph.labels,
            barColors: activeColors,
            hideHover: 'always',
            xLabelAngle: 50
        });
    }

    renderLegend(graph, activeColors);
}

function renderLegend(graph, colors) {

    var activeColors = colors;

    if (!activeColors) {
        activeColors = defaultActiveColors;
    }

    // ViewModel
    var viewModel = {
        header: {
            columns: []
        },
        rows: []
    }

    // Populating
    if (graph.graph === "bars") {
        
        for(var p in graph.data)
        {
            var rowData = graph.data[p];
            viewModel.header.columns.push({
                value: rowData[graph.xkey]
            })
        }


        for (var yk in graph.ykeys) {

            var ykey = graph.ykeys[yk];
            var color = activeColors[yk % activeColors.length];

            var row = {
                id: ykey,
                header: graph.labels[yk],
                columns: []
            };

            for (var p in graph.data) {
                    var rowData = graph.data[p];
            
                    var column = {
                        value:   rowData[ykey],
                        color: color
                    };
                    row.columns.push(column);
               
            }

            viewModel.rows.push(row);
        }
    }
    else if (graph.graph === "donut") {

        for (var p in graph.data) {
            var rowData = graph.data[p];
            viewModel.header.columns.push({
                value: rowData.label
            })
        }

        var row = {
            header: graph.label,
            columns: []
        };

        for (var p in graph.data) {
            var rowData = graph.data[p];
            var color = activeColors[p % activeColors.length];

            var column = {
                value: rowData.value,
                color: color
            };
            row.columns.push(column);
        }

        viewModel.rows.push(row);
    }
    else
    {
        return "";
    }


    // Rendering view

    var template = $('#templ_table').html();
    Mustache.parse(template);
    var rendered = Mustache.render(template, viewModel);
    $('#'+graph.id).append(rendered);
}

// Warnings ---->

function renderContentWarnings(data) {

    // Creating view model

    var viewModel = {
        byLevel: {
            id: "levels",
            graph: "bars",
            xkey: 'level',
            ykeys: ['value'],
            labels: ['Alertes'],
            data: [{
                level: "Info",
                value: 0
            }, {
                level: "Minor",
                value: 0
            }, {
                level: "Major",
                value: 0
            }, {
                level: "Critical",
                value: 0
            }, {
                level: "Blocker",
                value: 0
            }]
        },
        files: []
    };


    for (var key in data.Warnings) {
        var warning = data.Warnings[key];

        viewModel.byLevel.data[warning.Level].value++;

        var file = {
            project: warning.Project,
            warnings: []
        };

        // Name
        var li = warning.File.lastIndexOf('/');
        if (li < 0) { li = warning.File.lastIndexOf('\\'); }
        file.name = warning.File.substring(li + 1);

        var found = false;
        for (var f in viewModel.files) {
            var vmFile = viewModel.files[f];
            if (vmFile.project === file.project && vmFile.name === file.name) {
                found = true;
                file = vmFile;
            }
        }

        if (!found) {
            viewModel.files.push(file);
        }

        var warningVm = {
            index: file.warnings.length + 1,
            message: warning.Message,
            level: "default",
            levelValue: warning.Level
        }

        if (warning.Level > 2) { warningVm.level = "danger"; }
        else if (warning.Level > 1) { warningVm.level = "warning"; }
        else if (warning.Level > 0) { warningVm.level = "info"; }
        else { warning.Level = "default"; }

        file.warnings.push(warningVm);
    }

    file.warnings = file.warnings.sort(function (a, b) { return b.levelValue - a.levelValue; });

    // Rendering view

    var template = $('#templ_warnings').html();
    Mustache.parse(template);
    var rendered = Mustache.render(template, viewModel);
    $('#content-items').html(rendered);

    // Graph
    renderGraph(viewModel.byLevel);

}

// Duplication ---->

function renderContentDuplication(data) {

    // Creating view model

    var viewModel = {
        portions: []
    };

    var id = 0;
    for (var key in data.Duplicates) {
        var duplicate = data.Duplicates[key];

        var portionVm = {
            id: "code-" + (id++),
            content: duplicate.Content,
            files: []
        }

        for (var f in duplicate.Portions) {
            var portion = duplicate.Portions[f];
            var fileVm = findProjectAndFilename(data, portion.File);
            fileVm.line = portion.Line;
            portionVm.files.push(fileVm);
        }

        viewModel.portions.push(portionVm);
    }

    // Rendering view

    var template = $('#templ_duplication').html();
    Mustache.parse(template);
    var rendered = Mustache.render(template, viewModel);
    $('#content-items').html(rendered);

}


function renderContentProject(data,index) {

    // Creating view model

    var viewModel = {
        files: [
            {
                name: "Code",
                files: []
            },
            {
                name: "Layout",
                files: []
            },
            {
                name: "Assets",
                files: []
            },
        ]
    };

    
    for (var p in data.Metrics.Projects) {

        if (p.toString() === index)
        {
            var project = data.Metrics.Projects[p];

            var projectFolder = project.Path.replace(getFilename(project.Path), "");
            var solutionFolder = data.Metrics.Path.replace(getFilename(data.Metrics.Path), "");

            for (var f in project.Files) {
                var file = project.Files[f];

                var methodsVm = {
                    header: ["Complexité"],
                    rows: []
                };

                for (var m in file.Methods) {
                    var method = file.Methods[m];

                    methodsVm.rows.push({
                        header: method.Name,
                        color: defaultActiveColors[1],
                        columns: [{ value: method.CyclomaticComplexity }]
                    });
                };

                var fileMetrics = [];

                var category = null;
                var isAsset = file.Categories.indexOf("Assets") >= 0;
                var isCode = file.Categories.indexOf("Code") >= 0;
                var isLayout = file.Categories.indexOf("Layout") >= 0;

                if (isAsset)
                {
                    category = viewModel.files[2];
                    fileMetrics.push({
                        header: "Taille (Ko)",
                        color: defaultActiveColors[3],
                        value: file.Size
                    });
                }

                if (isCode)
                {
                    category = viewModel.files[0];
                    fileMetrics.push({
                        header: "Lignes de code",
                        color: defaultActiveColors[0],
                        value: file.LinesOfCode
                    });

                    fileMetrics.push({
                        header: "Lignes de commentaires",
                        color: defaultActiveColors[0],
                        value: file.LinesOfComments
                    });
                }

                if(isLayout)
                {
                    category = viewModel.files[1];
                }

                if (isCode && !isLayout) {
                    fileMetrics.push({
                        header: "Déclarations de types",
                        color: defaultActiveColors[2],
                        value: file.TypeDeclarations
                    });
                    fileMetrics.push({
                        header: "Déclarations de members",
                        color: defaultActiveColors[2],
                        value: file.MemberDeclarations
                    });
                    fileMetrics.push({
                        header: "Déclarations de méthodes",
                        color: defaultActiveColors[2],
                        value: file.MethodDeclarations
                    });

                }

                category.files.push({
                    name: file.File.replace(projectFolder,"").replace(solutionFolder,""),
                    project: project.SimplifiedName,
                    hasMethods: methodsVm.rows.length > 0,
                    methods: methodsVm,
                    metrics: fileMetrics
                })
            }
        }
    }

    // Rendering view

    var template = $('#templ_project').html();
    Mustache.parse(template);
    var rendered = Mustache.render(template, viewModel);
    $('#content-items').html(rendered);
}

main();

// Routing ------->
/*
var routes = {
    '/index': author,
    '/warnings': [books, function () { }],
    '/duplication': viewBook
};

var router = Router(routes);

router.init();*/