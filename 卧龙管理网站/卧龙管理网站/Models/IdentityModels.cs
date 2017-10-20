using System.Collections;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WollonMe.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Collections.Generic;
using System;

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

        [ForeignKey("FileImage")]
        public int FileID { set; get; }
        public virtual FileModel FileImage { get; set; }

        [ForeignKey("Group")]
        public int GroupID { set; get; }

        public virtual GroupModel Group { set; get; }

        [ForeignKey("Position")]
        public int PositionID { set; get; }

        public virtual PositionModel Position { set; get; }


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

        public DbSet<FileModel> FileModels { get; set; }
        public DbSet<GroupModel> GroupModels { set; get; }
        public DbSet<PositionModel> PositionModels { set; get; }
        public DbSet<HomePageModel> HomePageModels { set; get; }
        public DbSet<BlogModel> BlogModels { set; get; }
        public DbSet<MainKindModel> MainKindModels { set; get; }
        public DbSet<PerKindModel> PerKindModels { set; get; }
        public DbSet<TagModel> TagModels { set; get; }
        public DbSet<LevelModel> LevelModels { set; get; }
        public DbSet<RemarkModel> RemarkModels { set; get; }

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

            FileModel defaultImg = new FileModel();
            defaultImg.FileName = "defaultImg";
            defaultImg.FileKind = "img";
            defaultImg.UpTime = DateTime.Now;
            defaultImg.FileUrl = "default";
            context.FileModels.Add(defaultImg);

            GroupModel defaultGroup = new GroupModel();
            defaultGroup.GroupName = "未分组";
            context.GroupModels.Add(defaultGroup);

            PositionModel defaultPostion = new PositionModel();
            defaultPostion.PositionName = "未入职";
            context.PositionModels.Add(defaultPostion);

            LevelModel defaultLevel = new LevelModel();
            defaultLevel.LevelName = "普通";
            context.LevelModels.Add(defaultLevel);

            MainKindModel defaultMainKind = new MainKindModel();
            defaultMainKind.MainKindName = "未分类";
            context.MainKindModels.Add(defaultMainKind);
        }
    }
}