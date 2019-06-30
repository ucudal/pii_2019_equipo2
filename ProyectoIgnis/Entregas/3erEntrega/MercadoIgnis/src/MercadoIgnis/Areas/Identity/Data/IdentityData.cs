using System;

namespace MercadoIgnis.Areas.Identity.Data
{
    public static class IdentityData
    {
        public const string AdminUserName = "admin@ignis.com";
        public const string AdminName = "Administrador";
        public const string AdminMail = "admin@ignis.com";
        public static DateTime AdminDOB = new DateTime(1967, 3, 31);
        public const string AdminPassword = "P@55w0rd";
        public const string AdminRoleName = "Administrador";
        public const string ClienteRoleName = "Cliente";
        public const string TecnicoRoleName = "Técnico";
        //Auth
        public const string AuthAdminOTecnico = "Administrador,Técnico";
        public static string[] NonAdminRoleNames = new string[] { "Cliente", "Técnico" };
        public static string[] AllRoleNames = new string[] { "Cliente", "Técnico", "Administrador" };

    }
}