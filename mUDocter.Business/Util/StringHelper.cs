using System;

namespace mUDocter.Business.Util
{
    public class StringHelper
    {
        public static String ConvertStatus(int status)
        {
            switch (status)
            {
                case 0:
                    return "Chờ duyệt";
                case 1:
                    return "Hoạt động";
                case 2:
                    return "Khóa";
                default:
                    return "Không xác định";
            }
        }
        public static String ConvertBoookStatus(int status)
        {
            switch (status)
            {
                case 0:
                    return "Chờ Xác nhận";
                case 1:
                    return "Đã xác nhận";
                case 2:
                    return "Hoàn thành";
                case 3:
                    return "Bệnh nhân Hủy";
                case 4:
                    return "Nhân viên Hủy";
                default:
                    return "Không xác định";
            }
        }
    }

    //DAT_LICH = 0,
    //    BS_NHAN_LICH = 1,
    //    HOAN_THANH = 2,
    //    BN_HUY_LICH = 3,
    //    BS_HUY_LICH = 4,
    //    HE_THONG_HUY = 5
}
