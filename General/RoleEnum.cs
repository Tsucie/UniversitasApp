namespace UniversitasApp.General
{
    public enum RoleEnum
    {
        /// <summary>
        /// Akun Developer: Full Akses
        /// </summary>
        Principal_User = 1,

        /// <summary>
        /// Akun Pemilik Kampus: Dashboard(Total User, UserOnline, Finance Report, IPK Report), SiteList, RoleSite, StaffList, MhsList
        /// </summary>
        Client_User = 2,

        /// <summary>
        /// Akun Rektor dan Wakil Rektor: Dashboard(Total User, IPK Report), StaffList, SCList, FakultasList
        /// </summary>
        Site_User = 3,

        /// <summary>
        /// Akun Dekan dan Wakil Dekan: Dashboard, Fakultas, Kaprodi Position
        /// </summary>
        Principal_Staff_User = 4,

        /// <summary>
        /// Akun Kaprodi dan Wakil Kaprodi: Dashboard, MataKuliah, Dosen Position
        /// </summary>
        CoPrincipal_Staff_User = 5
    }
}