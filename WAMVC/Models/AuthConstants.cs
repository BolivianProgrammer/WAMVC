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
    /// Constantes para las políticas de autorización
    /// </summary>
    public static class Policies
    {
        // Políticas basadas en roles
        public const string RequiereAdministrador = "RequiereAdministrador";
        public const string RequiereUsuario = "RequiereUsuario";
        
        // Políticas combinadas
        public const string RequiereUsuarioAutenticado = "RequiereUsuarioAutenticado";
    }
}
