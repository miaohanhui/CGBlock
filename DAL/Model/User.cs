using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CGBlcok.DAL.Model
{
    [Table("User")] //自动建表的表名
    public class User
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        [Required] //必填项（非空）
        [MaxLength(50)] //最大长度（50）
        [Display(Name = "用户名")]
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Required]
        [Display(Name ="性别")]
        public bool Gender { set; get; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Required]
        public bool IsEnable { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [MaxLength(50)]
        [Display(Name ="真实姓名")]
        public string RealName { get; set; }

        [MaxLength(300)]
        [Display(Name = "备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        public virtual ICollection<Role> Roles { set; get; }
    }
}