namespace Bridge.Ractive
{
    [External]
    public interface ICancellable
    {
        /// <summary>
        /// Remove the handlers
        /// </summary>
        void Cancel();
    }
}