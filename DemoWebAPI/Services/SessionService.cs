using DemoWebAPI.Dtos;

namespace DemoWebAPI.Services
{
    public class SessionService
    {
        private UserInfoDTO _userInfo;

        public SessionService()
        {
            _userInfo = new();
        }

        public void SetInfo(UserInfoDTO userInfo)
        {
            _userInfo = userInfo;
        }

        public int UserId => _userInfo.UserId;
        public string? Username => _userInfo.UserName;
        public string? Fullname => _userInfo.Fullname;
        public int? BranchId => _userInfo.BranchId;
        public string? BranchCode => _userInfo.BranchCode;
    }
}
