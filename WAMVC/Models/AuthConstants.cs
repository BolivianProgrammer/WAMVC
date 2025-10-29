namespace WAMVC.Models
{
    /// <summary>
    /// Constantes para los roles del sistema
    /// </summary>
    public static class Roles
    {
        public const string Administrador = "Administrador";
        public const string Usuario = "Usuario";
    }

    /// <summary>
    /// Constantes para las pol�ticas de autorizaci�n
    /// </summary>
    public static class Policies
    {
        // Pol�ticas basadas en roles
        public const string RequiereAdministrador = "RequiereAdministrador";
        public const string RequiereUsuario = "RequiereUsuario";
        
        // Pol�ticas combinadas
        public const string RequiereUsuarioAutenticado = "RequiereUsuarioAutenticado";
    }
}
