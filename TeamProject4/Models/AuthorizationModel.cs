namespace Team_Project_4.Models
{
    public class AuthorizationModel
    {
        public enum UserRole
        {
            Manager,
            Staff
        }

        public class AuthorizationItem
        {
            public UserRole Role { get; set; }
            public List<string> Permissions { get; set; } = new List<string>();
        }

        // Danh sách các quyền cụ thể
        public static class Permissions
        {
            // Quản lý nhân viên
            public const string ViewStaffList = "ViewStaffList";
            public const string CreateStaff = "CreateStaff";
            public const string EditStaff = "EditStaff";
            
            // Quản lý phòng
            public const string ViewRooms = "ViewRooms";
            public const string ManageRooms = "ManageRooms";
            
            // Quản lý khách
            public const string ViewClients = "ViewClients";
            public const string ManageClients = "ManageClients";
            
            // Quản lý hóa đơn
            public const string CreateBills = "CreateBills";
            public const string ViewAllBills = "ViewAllBills";
        }

        // Cấu hình quyền mặc định cho từng role
        public static List<AuthorizationItem> DefaultPermissions = new List<AuthorizationItem>
        {
            new AuthorizationItem
            {
                Role = UserRole.Manager,
                Permissions = new List<string>
                {
                    Permissions.ViewStaffList,
                    Permissions.CreateStaff,
                    Permissions.EditStaff,
                    Permissions.ManageRooms,
                    Permissions.ManageClients,
                    Permissions.ViewAllBills
                }
            },
            new AuthorizationItem
            {
                Role = UserRole.Staff,
                Permissions = new List<string>
                {
                    Permissions.ViewRooms,
                    Permissions.ViewClients,
                    Permissions.CreateBills
                }
            }
        };
    }
}