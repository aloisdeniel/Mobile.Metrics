var jsonReport = '{"Metrics":{"Name":"Mobile.Metrics.Example.sln","Path":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.sln","Projects":[{"Name":"Mobile.Metrics.Example.Models","Categories":[],"Path":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Mobile.Metrics.Example.Models.csproj","Files":[{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\DataAccess\\\\CustomerDataAccess.cs","Methods":[{"Name":"CustomerDataAccess(IRepository<Customer> repository, IRestService service)","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"GetCustomers() : Task<IEnumerable<Customer>>","CyclomaticComplexity":2,"HalsteadVolume":0},{"Name":"GetCustomersInternal() : Task<IEnumerable<Customer>>","CyclomaticComplexity":2,"HalsteadVolume":0},{"Name":"GetCustomer(int id) : Task<Customer>","CyclomaticComplexity":2,"HalsteadVolume":0},{"Name":"GetCustomerInternal(int id) : Task<Customer>","CyclomaticComplexity":2,"HalsteadVolume":0}],"Categories":["Code"],"Lines":46,"LinesOfCode":46,"LinesOfComments":0,"TypeDeclarations":1,"MemberDeclarations":4,"MethodDeclarations":5,"Size":2550,"MethodsTotal":{"CyclomaticComplexity":9,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Entities\\\\Contact.cs","Methods":[{"Name":"Firstname.get() : string","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Firstname.set(string value) : void","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Lastname.get() : string","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Lastname.set(string value) : void","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"PhoneNumber.get() : string","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"PhoneNumber.set(string value) : void","CyclomaticComplexity":1,"HalsteadVolume":0}],"Categories":["Code"],"Lines":9,"LinesOfCode":9,"LinesOfComments":0,"TypeDeclarations":1,"MemberDeclarations":3,"MethodDeclarations":0,"Size":337,"MethodsTotal":{"CyclomaticComplexity":6,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Entities\\\\Customer.cs","Methods":[{"Name":"Customer()","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Name.get() : string","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Name.set(string value) : void","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Identifier.get() : int","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Identifier.set(int value) : void","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Contacts.get() : IEnumerable<Contact>","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Contacts.set(IEnumerable<Contact> value) : void","CyclomaticComplexity":1,"HalsteadVolume":0}],"Categories":["Code"],"Lines":23,"LinesOfCode":8,"LinesOfComments":15,"TypeDeclarations":1,"MemberDeclarations":3,"MethodDeclarations":1,"Size":833,"MethodsTotal":{"CyclomaticComplexity":7,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Helpers\\\\Async.cs","Methods":[{"Name":"FromResult(T result) : Task<T>","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Empty() : Task","CyclomaticComplexity":1,"HalsteadVolume":0}],"Categories":["Code"],"Lines":14,"LinesOfCode":14,"LinesOfComments":0,"TypeDeclarations":2,"MemberDeclarations":0,"MethodDeclarations":2,"Size":599,"MethodsTotal":{"CyclomaticComplexity":2,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Repositories\\\\CustomerRepository.cs","Methods":[{"Name":"All() : Task<IEnumerable<Customer>>","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Delete(Customer entity) : Task","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"FirstOrDefault(Func<Customer, bool> predicate) : Task<Customer>","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Insert(IEnumerable<Customer> entities) : Task","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Insert(Customer entity) : Task","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Where(Func<Customer, bool> predicate) : Task<IEnumerable<Customer>>","CyclomaticComplexity":1,"HalsteadVolume":0}],"Categories":["Code"],"Lines":25,"LinesOfCode":25,"LinesOfComments":0,"TypeDeclarations":1,"MemberDeclarations":1,"MethodDeclarations":6,"Size":1416,"MethodsTotal":{"CyclomaticComplexity":6,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Repositories\\\\IRepository.cs","Methods":[{"Name":"Insert(T entity) : Task","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Insert(IEnumerable<T> entities) : Task","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Delete(T entity) : Task","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"All() : Task<IEnumerable<T>>","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Where(Func<T,bool> predicate) : Task<IEnumerable<T>>","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"FirstOrDefault(Func<T, bool> predicate) : Task<T>","CyclomaticComplexity":1,"HalsteadVolume":0}],"Categories":["Code"],"Lines":13,"LinesOfCode":13,"LinesOfComments":0,"TypeDeclarations":1,"MemberDeclarations":0,"MethodDeclarations":6,"Size":514,"MethodsTotal":{"CyclomaticComplexity":6,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Web\\\\IRestService.cs","Methods":[{"Name":"GetCustomers() : Task<IEnumerable<Customer>>","CyclomaticComplexity":1,"HalsteadVolume":0}],"Categories":["Code"],"Lines":9,"LinesOfCode":9,"LinesOfComments":0,"TypeDeclarations":1,"MemberDeclarations":0,"MethodDeclarations":1,"Size":326,"MethodsTotal":{"CyclomaticComplexity":1,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Web\\\\WebRestService.cs","Methods":[{"Name":"GetCustomers() : Task<IEnumerable<Customer>>","CyclomaticComplexity":1,"HalsteadVolume":0}],"Categories":["Code"],"Lines":47,"LinesOfCode":47,"LinesOfComments":0,"TypeDeclarations":1,"MemberDeclarations":0,"MethodDeclarations":1,"Size":2298,"MethodsTotal":{"CyclomaticComplexity":1,"HalsteadVolume":0}}],"FilesTotal":{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Mobile.Metrics.Example.Models.csproj","Methods":[],"Lines":186,"LinesOfCode":171,"LinesOfComments":15,"TypeDeclarations":9,"MemberDeclarations":11,"MethodDeclarations":22,"Size":0,"MethodsTotal":{"CyclomaticComplexity":38,"HalsteadVolume":0}}},{"Name":"Mobile.Metrics.Example.ViewModels","Categories":[],"Path":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.ViewModels\\\\Mobile.Metrics.Example.ViewModels.csproj","Files":[{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.ViewModels\\\\CustomerViewModel.cs","Methods":[{"Name":"CustomerViewModel(CustomerDataAccess dataAccess)","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"IsUpdating.get() : bool","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"IsUpdating.set(bool value) : void","CyclomaticComplexity":2,"HalsteadVolume":0},{"Name":"Contacts.get() : IEnumerable<Contact>","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Contacts.set(IEnumerable<Contact> value) : void","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Name.get() : string","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Name.set(string value) : void","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"UpdateCommand.get() : RelayCommand<int>","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"UpdateCommand.set(RelayCommand<int> value) : void","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"ExecuteUpdateCommand(int id) : void","CyclomaticComplexity":3,"HalsteadVolume":0},{"Name":"CanExecuteUpdateCommand(int id) : bool","CyclomaticComplexity":1,"HalsteadVolume":0}],"Categories":["Code"],"Lines":46,"LinesOfCode":46,"LinesOfComments":0,"TypeDeclarations":1,"MemberDeclarations":8,"MethodDeclarations":3,"Size":2219,"MethodsTotal":{"CyclomaticComplexity":14,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.ViewModels\\\\HomeViewModel.cs","Methods":[{"Name":"HomeViewModel(CustomerDataAccess dataAccess)","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"IsUpdating.get() : bool","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"IsUpdating.set(bool value) : void","CyclomaticComplexity":2,"HalsteadVolume":0},{"Name":"Customers.get() : IEnumerable<Customer>","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Customers.set(IEnumerable<Customer> value) : void","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"UpdateCommand.get() : RelayCommand","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"UpdateCommand.set(RelayCommand value) : void","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"ExecuteUpdateCommand() : void","CyclomaticComplexity":3,"HalsteadVolume":0},{"Name":"CanExecuteUpdateCommand() : bool","CyclomaticComplexity":1,"HalsteadVolume":0}],"Categories":["Code"],"Lines":40,"LinesOfCode":40,"LinesOfComments":0,"TypeDeclarations":1,"MemberDeclarations":6,"MethodDeclarations":3,"Size":1920,"MethodsTotal":{"CyclomaticComplexity":12,"HalsteadVolume":0}}],"FilesTotal":{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.ViewModels\\\\Mobile.Metrics.Example.ViewModels.csproj","Methods":[],"Lines":86,"LinesOfCode":86,"LinesOfComments":0,"TypeDeclarations":2,"MemberDeclarations":14,"MethodDeclarations":6,"Size":0,"MethodsTotal":{"CyclomaticComplexity":26,"HalsteadVolume":0}}},{"Name":"Mobile.Metrics.Example.Windows","Categories":[],"Path":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Mobile.Metrics.Example.Windows.csproj","Files":[{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Assets\\\\Logo.scale-100.png","Methods":[],"Categories":["Assets"],"Lines":0,"LinesOfCode":0,"LinesOfComments":0,"TypeDeclarations":0,"MemberDeclarations":0,"MethodDeclarations":0,"Size":801,"MethodsTotal":{"CyclomaticComplexity":0,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Assets\\\\SmallLogo.scale-100.png","Methods":[],"Categories":["Assets"],"Lines":0,"LinesOfCode":0,"LinesOfComments":0,"TypeDeclarations":0,"MemberDeclarations":0,"MethodDeclarations":0,"Size":329,"MethodsTotal":{"CyclomaticComplexity":0,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Assets\\\\SplashScreen.scale-100.png","Methods":[],"Categories":["Assets"],"Lines":0,"LinesOfCode":0,"LinesOfComments":0,"TypeDeclarations":0,"MemberDeclarations":0,"MethodDeclarations":0,"Size":2146,"MethodsTotal":{"CyclomaticComplexity":0,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Assets\\\\StoreLogo.scale-100.png","Methods":[],"Categories":["Assets"],"Lines":0,"LinesOfCode":0,"LinesOfComments":0,"TypeDeclarations":0,"MemberDeclarations":0,"MethodDeclarations":0,"Size":429,"MethodsTotal":{"CyclomaticComplexity":0,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Pages\\\\CustomerPage.xaml","Methods":[],"Categories":["View","Layout","Code"],"Lines":33,"LinesOfCode":33,"LinesOfComments":0,"TypeDeclarations":0,"MemberDeclarations":1,"MethodDeclarations":0,"Size":1524,"MethodsTotal":{"CyclomaticComplexity":0,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Pages\\\\CustomerPage.xaml.cs","Methods":[{"Name":"CustomerPage()","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"ViewModel.get() : CustomerViewModel","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"OnNavigatedTo(NavigationEventArgs e) : void","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"Button_Click(object sender, RoutedEventArgs e) : void","CyclomaticComplexity":1,"HalsteadVolume":0}],"Categories":["Code","View"],"Lines":31,"LinesOfCode":27,"LinesOfComments":4,"TypeDeclarations":1,"MemberDeclarations":1,"MethodDeclarations":3,"Size":1453,"MethodsTotal":{"CyclomaticComplexity":4,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Pages\\\\HomePage.xaml","Methods":[],"Categories":["View","Layout","Code"],"Lines":33,"LinesOfCode":33,"LinesOfComments":0,"TypeDeclarations":0,"MemberDeclarations":1,"MethodDeclarations":0,"Size":1539,"MethodsTotal":{"CyclomaticComplexity":0,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Pages\\\\HomePage.xaml.cs","Methods":[{"Name":"HomePage()","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"ViewModel.get() : HomeViewModel","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"CustomerListView_ItemClick(object sender, ItemClickEventArgs e) : void","CyclomaticComplexity":1,"HalsteadVolume":0}],"Categories":["Code","View"],"Lines":30,"LinesOfCode":26,"LinesOfComments":4,"TypeDeclarations":1,"MemberDeclarations":1,"MethodDeclarations":2,"Size":1396,"MethodsTotal":{"CyclomaticComplexity":3,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Shared\\\\App.xaml.cs","Methods":[{"Name":"App()","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"OnLaunched(LaunchActivatedEventArgs e) : void","CyclomaticComplexity":5,"HalsteadVolume":0},{"Name":"OnSuspending(object sender, SuspendingEventArgs e) : void","CyclomaticComplexity":1,"HalsteadVolume":0}],"Categories":["Code","View"],"Lines":108,"LinesOfCode":69,"LinesOfComments":39,"TypeDeclarations":1,"MemberDeclarations":0,"MethodDeclarations":3,"Size":6026,"MethodsTotal":{"CyclomaticComplexity":7,"HalsteadVolume":0}}],"FilesTotal":{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Mobile.Metrics.Example.Windows.csproj","Methods":[],"Lines":235,"LinesOfCode":188,"LinesOfComments":47,"TypeDeclarations":3,"MemberDeclarations":4,"MethodDeclarations":8,"Size":0,"MethodsTotal":{"CyclomaticComplexity":14,"HalsteadVolume":0}}},{"Name":"Mobile.Metrics.Example.WindowsPhone","Categories":[],"Path":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.WindowsPhone\\\\Mobile.Metrics.Example.WindowsPhone.csproj","Files":[{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.WindowsPhone\\\\Assets\\\\Logo.scale-240.png","Methods":[],"Categories":["Assets"],"Lines":0,"LinesOfCode":0,"LinesOfComments":0,"TypeDeclarations":0,"MemberDeclarations":0,"MethodDeclarations":0,"Size":2516,"MethodsTotal":{"CyclomaticComplexity":0,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.WindowsPhone\\\\Assets\\\\SmallLogo.scale-240.png","Methods":[],"Categories":["Assets"],"Lines":0,"LinesOfCode":0,"LinesOfComments":0,"TypeDeclarations":0,"MemberDeclarations":0,"MethodDeclarations":0,"Size":753,"MethodsTotal":{"CyclomaticComplexity":0,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.WindowsPhone\\\\Assets\\\\SplashScreen.scale-240.png","Methods":[],"Categories":["Assets"],"Lines":0,"LinesOfCode":0,"LinesOfComments":0,"TypeDeclarations":0,"MemberDeclarations":0,"MethodDeclarations":0,"Size":14715,"MethodsTotal":{"CyclomaticComplexity":0,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.WindowsPhone\\\\Assets\\\\Square71x71Logo.scale-240.png","Methods":[],"Categories":["Assets"],"Lines":0,"LinesOfCode":0,"LinesOfComments":0,"TypeDeclarations":0,"MemberDeclarations":0,"MethodDeclarations":0,"Size":1122,"MethodsTotal":{"CyclomaticComplexity":0,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.WindowsPhone\\\\Assets\\\\StoreLogo.scale-240.png","Methods":[],"Categories":["Assets"],"Lines":0,"LinesOfCode":0,"LinesOfComments":0,"TypeDeclarations":0,"MemberDeclarations":0,"MethodDeclarations":0,"Size":2200,"MethodsTotal":{"CyclomaticComplexity":0,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.WindowsPhone\\\\Assets\\\\WideLogo.scale-240.png","Methods":[],"Categories":["Assets"],"Lines":0,"LinesOfCode":0,"LinesOfComments":0,"TypeDeclarations":0,"MemberDeclarations":0,"MethodDeclarations":0,"Size":4530,"MethodsTotal":{"CyclomaticComplexity":0,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.WindowsPhone\\\\Pages\\\\HomePage.xaml","Methods":[],"Categories":["View","Layout","Code"],"Lines":11,"LinesOfCode":11,"LinesOfComments":0,"TypeDeclarations":0,"MemberDeclarations":0,"MethodDeclarations":0,"Size":516,"MethodsTotal":{"CyclomaticComplexity":0,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.WindowsPhone\\\\Pages\\\\HomePage.xaml.cs","Methods":[{"Name":"HomePage()","CyclomaticComplexity":1,"HalsteadVolume":0}],"Categories":["Code","View"],"Lines":22,"LinesOfCode":18,"LinesOfComments":4,"TypeDeclarations":1,"MemberDeclarations":0,"MethodDeclarations":1,"Size":857,"MethodsTotal":{"CyclomaticComplexity":1,"HalsteadVolume":0}},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Shared\\\\App.xaml.cs","Methods":[{"Name":"App()","CyclomaticComplexity":1,"HalsteadVolume":0},{"Name":"OnLaunched(LaunchActivatedEventArgs e) : void","CyclomaticComplexity":5,"HalsteadVolume":0},{"Name":"OnSuspending(object sender, SuspendingEventArgs e) : void","CyclomaticComplexity":1,"HalsteadVolume":0}],"Categories":["Code","View"],"Lines":108,"LinesOfCode":69,"LinesOfComments":39,"TypeDeclarations":1,"MemberDeclarations":0,"MethodDeclarations":3,"Size":6026,"MethodsTotal":{"CyclomaticComplexity":7,"HalsteadVolume":0}}],"FilesTotal":{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.WindowsPhone\\\\Mobile.Metrics.Example.WindowsPhone.csproj","Methods":[],"Lines":141,"LinesOfCode":98,"LinesOfComments":43,"TypeDeclarations":2,"MemberDeclarations":0,"MethodDeclarations":4,"Size":0,"MethodsTotal":{"CyclomaticComplexity":8,"HalsteadVolume":0}}}],"TotalProjectCategories":{}},"Warnings":[{"Level":1,"Project":"Mobile.Metrics.Example.Models","File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\DataAccess\\\\CustomerDataAccess.cs","Message":"Le fichier comporte un faible pourcentage de commentaires (0.00%)","WorkAround":"Documenter d\'avantage les api publiques, commenter les algorithmes complexes."},{"Level":1,"Project":"Mobile.Metrics.Example.Models","File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Entities\\\\Contact.cs","Message":"Le fichier comporte un faible pourcentage de commentaires (0.00%)","WorkAround":"Documenter d\'avantage les api publiques, commenter les algorithmes complexes."},{"Level":1,"Project":"Mobile.Metrics.Example.Models","File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Helpers\\\\Async.cs","Message":"Le fichier comporte un faible pourcentage de commentaires (0.00%)","WorkAround":"Documenter d\'avantage les api publiques, commenter les algorithmes complexes."},{"Level":1,"Project":"Mobile.Metrics.Example.Models","File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Repositories\\\\CustomerRepository.cs","Message":"Le fichier comporte un faible pourcentage de commentaires (0.00%)","WorkAround":"Documenter d\'avantage les api publiques, commenter les algorithmes complexes."},{"Level":1,"Project":"Mobile.Metrics.Example.Models","File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Repositories\\\\IRepository.cs","Message":"Le fichier comporte un faible pourcentage de commentaires (0.00%)","WorkAround":"Documenter d\'avantage les api publiques, commenter les algorithmes complexes."},{"Level":1,"Project":"Mobile.Metrics.Example.Models","File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Web\\\\IRestService.cs","Message":"Le fichier comporte un faible pourcentage de commentaires (0.00%)","WorkAround":"Documenter d\'avantage les api publiques, commenter les algorithmes complexes."},{"Level":1,"Project":"Mobile.Metrics.Example.Models","File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Web\\\\WebRestService.cs","Message":"Le fichier comporte un faible pourcentage de commentaires (0.00%)","WorkAround":"Documenter d\'avantage les api publiques, commenter les algorithmes complexes."},{"Level":1,"Project":"Mobile.Metrics.Example.ViewModels","File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.ViewModels\\\\CustomerViewModel.cs","Message":"Le fichier comporte un faible pourcentage de commentaires (0.00%)","WorkAround":"Documenter d\'avantage les api publiques, commenter les algorithmes complexes."},{"Level":1,"Project":"Mobile.Metrics.Example.ViewModels","File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.ViewModels\\\\HomeViewModel.cs","Message":"Le fichier comporte un faible pourcentage de commentaires (0.00%)","WorkAround":"Documenter d\'avantage les api publiques, commenter les algorithmes complexes."},{"Level":1,"Project":"Mobile.Metrics.Example.Windows","File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Pages\\\\CustomerPage.xaml","Message":"Le fichier comporte un faible pourcentage de commentaires (0.00%)","WorkAround":"Documenter d\'avantage les api publiques, commenter les algorithmes complexes."},{"Level":1,"Project":"Mobile.Metrics.Example.Windows","File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Pages\\\\CustomerPage.xaml.cs","Message":"Le fichier comporte un faible pourcentage de commentaires (12.90%)","WorkAround":"Documenter d\'avantage les api publiques, commenter les algorithmes complexes."},{"Level":1,"Project":"Mobile.Metrics.Example.Windows","File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Pages\\\\HomePage.xaml","Message":"Le fichier comporte un faible pourcentage de commentaires (0.00%)","WorkAround":"Documenter d\'avantage les api publiques, commenter les algorithmes complexes."},{"Level":1,"Project":"Mobile.Metrics.Example.Windows","File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Pages\\\\HomePage.xaml.cs","Message":"Le fichier comporte un faible pourcentage de commentaires (13.33%)","WorkAround":"Documenter d\'avantage les api publiques, commenter les algorithmes complexes."},{"Level":1,"Project":"Mobile.Metrics.Example.WindowsPhone","File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.WindowsPhone\\\\Pages\\\\HomePage.xaml","Message":"Le fichier comporte un faible pourcentage de commentaires (0.00%)","WorkAround":"Documenter d\'avantage les api publiques, commenter les algorithmes complexes."},{"Level":1,"Project":"Mobile.Metrics.Example.WindowsPhone","File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.WindowsPhone\\\\Pages\\\\HomePage.xaml.cs","Message":"Le fichier comporte un faible pourcentage de commentaires (18.18%)","WorkAround":"Documenter d\'avantage les api publiques, commenter les algorithmes complexes."},{"Level":2,"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.sln","Message":"La solution comporte un nombre élevé de portions de code dupliquées.","WorkAround":"Mutualiser les portions de code en créeant des types et méthodes supplémentaires."}],"Duplicates":[{"Content":"[assembly: AssemblyCopyright(\\"Copyright ©  2015\\")][assembly: AssemblyTrademark(\\"\\")]\\r\\n[assembly: AssemblyCulture(\\"\\")]\\r\\n[assembly: NeutralResourcesLanguage(\\"en\\")]\\r\\n\\r\\n// Version information for an assembly consists of the following four values:\\r\\n//\\r\\n//      Major Version\\r\\n//      Minor Version\\r\\n//      Build Number\\r\\n//      Revision\\r\\n//\\r\\n// You can specify all the values or you can default the Build and Revision Numbers\\r\\n// by using the \'*\' as shown below:\\r\\n// [assembly: AssemblyVersion(\\"1.0.*\\")]\\r\\n[assembly: AssemblyVersion(\\"1.0.0.0\\")]\\r\\n[assembly: AssemblyFileVersion(\\"1.0.0.0\\")]\\r\\n","Portions":[{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Models\\\\Properties\\\\AssemblyInfo.cs","Line":14},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.ViewModels\\\\Properties\\\\AssemblyInfo.cs","Line":14}]},{"Content":"#region Fields\\r\\nprivate CustomerDataAccess dataAccess;\\r\\n\\r\\nprivate bool isUpdating;\\r\\n\\r\\nprivate string name;\\r\\n\\r\\nprivate IEnumerable<Contact> contacts;\\r\\n\\r\\n#endregion\\r\\n\\r\\n\\r\\n#region Properties\\r\\n\\r\\npublic bool IsUpdating\\r\\n{\\r\\nget { return this.isUpdating; }\\r\\nset\\r\\n{\\r\\nif (this.Set(ref this.isUpdating, value))\\r\\n{\\r\\nthis.UpdateCommand.RaiseCanExecuteChanged();\\r\\n}\\r\\n}\\r\\n}\\r\\n\\r\\npublic IEnumerable<Contact> Contacts\\r\\n{\\r\\nget { return this.contacts; }\\r\\nset { this.Set(ref this.contacts, value); }\\r\\n}\\r\\n\\r\\npublic string Name\\r\\n{\\r\\nget { return this.name; }\\r\\nset { this.Set(ref this.name, value); }\\r\\n}\\r\\n\\r\\n#endregion\\r\\n\\r\\n#region Commands\\r\\n\\r\\npublic RelayCommand<int> UpdateCommand { get; private set; }\\r\\n\\r\\nprivate async void ExecuteUpdateCommand(int id)\\r\\n{\\r\\ntry\\r\\n{\\r\\nvar customer = await this.dataAccess.GetCustomer(id);\\r\\nthis.Name = customer.Name;\\r\\nthis.Contacts = customer.Contacts;\\r\\n}\\r\\ncatch (Exception e)\\r\\n{\\r\\nDebug.WriteLine(\\"Update failed : \\" + e.Message);\\r\\n}\\r\\n}\\r\\n\\r\\nprivate bool CanExecuteUpdateCommand(int id)\\r\\n{\\r\\nreturn !this.isUpdating;\\r\\n}\\r\\n\\r\\n#endregion\\r\\n}\\r\\n}\\r\\n","Portions":[{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.ViewModels\\\\CustomerViewModel.cs","Line":22},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.ViewModels\\\\HomeViewModel.cs","Line":22}]},{"Content":"catch (Exception e){\\r\\nDebug.WriteLine(\\"Update failed : \\" + e.Message);\\r\\n}\\r\\n}\\r\\n\\r\\nprivate bool CanExecuteUpdateCommand(int id)\\r\\n{\\r\\nreturn !this.isUpdating;\\r\\n}\\r\\n\\r\\n#endregion\\r\\n}\\r\\n}\\r\\n","Portions":[{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.ViewModels\\\\CustomerViewModel.cs","Line":75},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.ViewModels\\\\HomeViewModel.cs","Line":64}]},{"Content":"return !this.isUpdating;}\\r\\n\\r\\n#endregion\\r\\n}\\r\\n}\\r\\n","Portions":[{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.ViewModels\\\\CustomerViewModel.cs","Line":83},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.ViewModels\\\\HomeViewModel.cs","Line":72}]},{"Content":"x:Class=\\"Mobile.Metrics.Example.Pages.HomePage\\"xmlns=\\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\\"\\r\\nxmlns:x=\\"http://schemas.microsoft.com/winfx/2006/xaml\\"\\r\\nxmlns:local=\\"using:Mobile.Metrics.Example.Pages\\"\\r\\nxmlns:d=\\"http://schemas.microsoft.com/expression/blend/2008\\"\\r\\nxmlns:mc=\\"http://schemas.openxmlformats.org/markup-compatibility/2006\\"\\r\\nmc:Ignorable=\\"d\\">\\r\\n\\r\\n<Page.BottomAppBar>\\r\\n<CommandBar>\\r\\n<AppBarButton Label=\\"Refresh\\" Icon=\\"Refresh\\" Command=\\"{Binding UpdateCommand}\\"/>\\r\\n</CommandBar>\\r\\n</Page.BottomAppBar>\\r\\n\\r\\n<Grid Background=\\"{ThemeResource ApplicationPageBackgroundThemeBrush}\\">\\r\\n\\r\\n<Grid.RowDefinitions>\\r\\n<RowDefinition Height=\\"Auto\\" />\\r\\n<RowDefinition />\\r\\n</Grid.RowDefinitions>\\r\\n\\r\\n<TextBlock Margin=\\"10\\" FontSize=\\"35\\">\\r\\n<Run Text=\\"Customers : \\" />\\r\\n<Run Text=\\"{Binding Customers.Count}\\" />\\r\\n</TextBlock>\\r\\n\\r\\n<GridView Grid.Row=\\"1\\" x:Name=\\"CustomerListView\\" ItemsSource=\\"{Binding Customers}\\" SelectionMode=\\"None\\" IsItemClickEnabled=\\"True\\" ItemClick=\\"CustomerListView_ItemClick\\">\\r\\n<GridView.ItemTemplate>\\r\\n<DataTemplate>\\r\\n<StackPanel Width=\\"100\\" Height=\\"100\\" Background=\\"Brown\\">\\r\\n<TextBlock Text=\\"{Binding Name}\\" />\\r\\n</StackPanel>\\r\\n</DataTemplate>\\r\\n</GridView.ItemTemplate>\\r\\n</GridView>\\r\\n\\r\\n</Grid>\\r\\n</Page>\\r\\n","Portions":[{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Pages\\\\HomePage.xaml","Line":2},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.WindowsPhone\\\\Pages\\\\HomePage.xaml","Line":2}]},{"Content":"<Grid Background=\\"{ThemeResource ApplicationPageBackgroundThemeBrush}\\">\\r\\n<Grid.RowDefinitions>\\r\\n<RowDefinition Height=\\"Auto\\" />\\r\\n<RowDefinition />\\r\\n</Grid.RowDefinitions>\\r\\n\\r\\n<StackPanel Orientation=\\"Horizontal\\">\\r\\n<Button Content=\\"Back\\" Click=\\"Button_Click\\" />\\r\\n<TextBlock Margin=\\"10\\" FontSize=\\"35\\">\\r\\n<Run Text=\\"{Binding Name}\\" />\\r\\n</TextBlock>\\r\\n</StackPanel>\\r\\n\\r\\n\\r\\n<GridView Grid.Row=\\"1\\" x:Name=\\"CustomerListView\\" ItemsSource=\\"{Binding Contacts}\\" SelectionMode=\\"None\\">\\r\\n<GridView.ItemTemplate>\\r\\n<DataTemplate>\\r\\n<StackPanel Width=\\"100\\" Height=\\"100\\" Background=\\"BurlyWood\\">\\r\\n<TextBlock>\\r\\n<Run  Text=\\"{Binding Firstname}\\" />\\r\\n<Run  Text=\\"{Binding Lastname}\\" />\\r\\n</TextBlock>\\r\\n</StackPanel>\\r\\n</DataTemplate>\\r\\n</GridView.ItemTemplate>\\r\\n</GridView>\\r\\n\\r\\n</Grid>\\r\\n</Page>\\r\\n","Portions":[{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Pages\\\\CustomerPage.xaml","Line":10},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Pages\\\\HomePage.xaml","Line":16}]},{"Content":"</StackPanel></DataTemplate>\\r\\n</GridView.ItemTemplate>\\r\\n</GridView>\\r\\n\\r\\n</Grid>\\r\\n</Page>\\r\\n","Portions":[{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Pages\\\\CustomerPage.xaml","Line":33},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Pages\\\\HomePage.xaml","Line":33}]},{"Content":"public sealed partial class HomePage : Page{\\r\\npublic HomePage()\\r\\n{\\r\\nthis.InitializeComponent();\\r\\nthis.DataContext = SimpleIoc.Default.GetInstance<HomeViewModel>();\\r\\n}\\r\\n\\r\\nprivate HomeViewModel ViewModel { get { return this.DataContext as HomeViewModel; } }\\r\\n\\r\\nprivate void CustomerListView_ItemClick(object sender, ItemClickEventArgs e)\\r\\n{\\r\\nvar customer = e.ClickedItem as Customer;\\r\\nthis.Frame.Navigate(typeof(CustomerPage), customer.Identifier);\\r\\n}\\r\\n}\\r\\n}\\r\\n","Portions":[{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Pages\\\\HomePage.xaml.cs","Line":26},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.WindowsPhone\\\\Pages\\\\HomePage.xaml.cs","Line":23}]},{"Content":"[assembly: AssemblyCopyright(\\"Copyright ©  2015\\")][assembly: AssemblyTrademark(\\"\\")]\\r\\n[assembly: AssemblyCulture(\\"\\")]\\r\\n\\r\\n// Version information for an assembly consists of the following four values:\\r\\n//\\r\\n//      Major Version\\r\\n//      Minor Version\\r\\n//      Build Number\\r\\n//      Revision\\r\\n//\\r\\n// You can specify all the values or you can default the Build and Revision Numbers\\r\\n// by using the \'*\' as shown below:\\r\\n// [assembly: AssemblyVersion(\\"1.0.*\\")]\\r\\n[assembly: AssemblyVersion(\\"1.0.0.0\\")]\\r\\n[assembly: AssemblyFileVersion(\\"1.0.0.0\\")]\\r\\n[assembly: ComVisible(false)]\\r\\n","Portions":[{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.Windows\\\\Properties\\\\AssemblyInfo.cs","Line":13},{"File":"C:\\\\Users\\\\Alois Deniel\\\\Documents\\\\Mobile.Metrics\\\\Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example\\\\Mobile.Metrics.Example.WindowsPhone\\\\Properties\\\\AssemblyInfo.cs","Line":13}]}]}'; console.log(jsonReport); var report = JSON.parse(jsonReport);