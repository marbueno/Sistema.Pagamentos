namespace Sistema.Pagamentos.Services.SoftwareExpress.Interface
{
    public interface IConfiguration
    {
        #region Properties 

        string Url { get; }
        string Token { get; }

        #endregion Properties 
    }
}
