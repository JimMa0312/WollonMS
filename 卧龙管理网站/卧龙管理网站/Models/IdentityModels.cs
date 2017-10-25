using System.Collections;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using WollonMe.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;
using System;
using System.Web;
using System.Web.Mvc;

namespace 卧龙管理网站.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //昵称
        public string UserNick { get; set; }
        //QQ号
        public string UserQQ { get; set; }
        //微信
        public string UserWeChat { get; set; }
        //签名
        public string UserDes { get; set; }
        //性别
        public 卧龙管理网站.Models.Enum.Egender UserGender { get; set; }

        public int ImageId { set; get; }
        [ForeignKey("ImageId")]
        public virtual File FileImage { get; set; }

        public int F_GroupId { set; get; }
        [ForeignKey("GroupId")]
        public virtual Group Group { set; get; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {

            // 请注意，authenticationType 必须与 CookieAuthenticationOptions.AuthenticationType 中定义的相应项匹配
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // 在此处添加自定义用户声明
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<File> FileModels { get; set; }
        public DbSet<Group> GroupModels { set; get; }
        public DbSet<HomePage> HomePageModels { set; get; }
        public DbSet<Blog> BlogModels { set; get; }
        public DbSet<MainKind> MainKindModels { set; get; }
        public DbSet<PerKind> PerKindModels { set; get; }
        public DbSet<Tag> TagModels { set; get; }
        public DbSet<Level> LevelModels { set; get; }
        public DbSet<Remark> RemarkModels { set; get; }

        public ApplicationDbContext()
            : base("WollonMeDb", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class IdentityDbInit
        : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);

        }

        public void PerformInitialSetup(ApplicationDbContext context)
        {
            //初始化默认数据
        }
    }

    public class AppRole : IdentityRole
    {
        public AppRole() : base() { }

        public AppRole(string name) : base(name) { }
    }

    
    //HTML辅助器方法，用于根据用户ID获取用户名
    public static class IdentityHelpers
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            ApplicationUserManager mgr
                = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.UserName);
        }
    }
}