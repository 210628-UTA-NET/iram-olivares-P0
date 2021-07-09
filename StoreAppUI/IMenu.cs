namespace StoreAppUI
{
    /// <summary>
    /// AvailableMenu describes all possible menus the user will have access to
    /// </summary>
    public enum AvailableMenu{
        ExitApp,
        MainMenu,
        StoreMenu,
        AddCustomer,
        ShowAllCustomers,
        SearchForCustomer
    }
    public interface IMenu{
        /// <summary>
        /// CurrentMenu will describe the current menu state of the app
        /// Will display all possible options and allow for user input to traverse the app
        /// </summary>
        void CurrentMenu();

        /// <summary>
        /// ChooseMenu will allow user to travers menus based on input
        /// </summary>
        /// <returns> Returns the menu that will be traversed to </returns>
        AvailableMenu ChooseMenu();
    }
}