using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorTools.Models
{
    [Serializable]
    public class AddOrderRequest
    {
        /// <summary>
        /// 酒店ID
        /// </summary>
        public string HotelID { get; set; }

        /// <summary>
        /// 入住时间
        /// </summary>
        public DateTime CheckInDate { get; set; }

        /// <summary>
        /// 离店时间
        /// </summary>

        public DateTime CheckOutDate { get; set; }

        /// <summary>
        /// 预定数量
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 预定房型
        /// </summary>
        public string RoomTypeID { get; set; }

        /// <summary>
        /// 客人姓名
        /// </summary>
        public string MebName { get; set; }

        /// <summary>
        /// 客人电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 订单总价格（若有值会对价格做校验）
        /// </summary>
        public decimal? SumPrice { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 入住类型
        /// </summary>
        public string CheckInType { get; set; }

        /// <summary>
        /// 证件号
        /// </summary>
        public string PapersNO { get; set; }

        /// <summary>
        /// 是否担保
        /// </summary>
        public bool? IsGuarantee { get; set; }

        /// <summary>
        /// 活动码
        /// </summary>
        public string ActivityCode { get; set; }


        /// <summary>
        /// 外部订单号
        /// </summary>
        public string OutOrderID { get; set; }

        /// <summary>
        /// 会员登录电话
        /// </summary>
        public string MebTel { get; set; }

        /// <summary>
        /// 会员卡号
        /// </summary>
        public string MemberNo { get; set; }

        /// <summary>
        /// 会员登录密码
        /// </summary>
        public string MebPassword { get; set; }

        public int? OrderType { get; set; }

        /// <summary>
        /// 优惠卷Code
        /// </summary>
        public string CouponCode { get; set; }

        /// <summary>
        /// 会员卡号
        /// </summary>
        public string OldCardNO { get; set; }

        /// <summary>
        /// 价格类型
        /// </summary>
        public string RateType { get; set; }

        public string RateMemberType { get; set; }

        /// <summary>
        /// 价格码
        /// </summary>
        public string RateplanCode { get; set; }

        /// <summary>
        /// ota预定类型 1是协议预定，2会员预定
        /// </summary>
        public int? OTABookType { get; set; }

        /// <summary>
        /// 协议号
        /// </summary>
        public string AgreementNo { get; set; }

        /// <summary>
        /// 优惠券活动码
        /// </summary>
        public string CouponActivityCode { get; set; }
    }
}