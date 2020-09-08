using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CGBlcok.DAL.Model
{
    [Table("Role")]
    public class Role
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        [Required] //必填项（非空）
        [MaxLength(50)] //最大长度（50）
        [Display(Name = "角色名")]
        public string RoleName { get; set; }

        /// <summary>
        /// 角色等级
        /// </summary>
        [Required] //必填项（非空）
        [MaxLength(50)] //最大长度（50）
        [Display(Name = "角色等级")]
        public string RoleLevel { get; set; }

        [Required]
        public User User { set; get; }
    }
}