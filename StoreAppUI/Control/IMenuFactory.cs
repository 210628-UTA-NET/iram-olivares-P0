namespace StoreAppUI
{
    public interface IMenuFactory
    {
        /// <summary>
        /// This factory will decide the next menu to be returned
        /// </summary>
        /// <param name="p_menu"> input that acts as a switch to determine the next menu </param>
        /// <returns> returns the next menu to be chosen (interface for abstraction) </returns>
        IMenu GetMenu(AvailableMenu p_menu);
    }
}