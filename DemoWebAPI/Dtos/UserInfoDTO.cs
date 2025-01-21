namespace DemoWebAPI.Dtos
{
    public class UserInfoDTO
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Fullname { get; set; }
        public int BranchId { get; set; }
        public string? BranchCode { get; set; }
        public string? BranchName { get; set; }
    }
}
