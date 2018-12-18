using System.Reflection;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Modules;
using HuflitBigPrj.Authorization.Roles;
using HuflitBigPrj.Authorization.Users;
using HuflitBigPrj.Customer.DTO;
using HuflitBigPrj.Inventories.DTO;
using HuflitBigPrj.Models;
using HuflitBigPrj.Payment.DTO;
using HuflitBigPrj.PurchaseOrders.DTO;
using HuflitBigPrj.Roles.Dto;
using HuflitBigPrj.Users.Dto;

namespace HuflitBigPrj
{
    [DependsOn(typeof(HuflitBigPrjCoreModule), typeof(AbpAutoMapperModule))]
    public class HuflitBigPrjApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
           
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                #region PurchaseOrder
                mapper.CreateMap<CreatePurchaseOrderInput, PurchaseOrder>().ReverseMap();
                mapper.CreateMap<GetPurchaseOrderOutput, PurchaseOrder>().ReverseMap();
                mapper.CreateMap<UpdatePurchaseOrderInput, PurchaseOrder>().ReverseMap();
                #endregion

                #region Payment
                mapper.CreateMap<CreatePaymentInput, Models.Payment>().ReverseMap();
                mapper.CreateMap<Models.Payment, GetPaymentOutput>().ReverseMap();
                mapper.CreateMap<UpdatePaymentInput, Models.Payment>().ReverseMap();
                mapper.CreateMap<Models.Payment, GetPaymentOutput>().ReverseMap();
                #endregion

                #region Inventory
                mapper.CreateMap<CreateInventoryInput, Inventory>().ReverseMap();
                mapper.CreateMap<GetInventoryOutput, Inventory>().ReverseMap();
                mapper.CreateMap<UpdateInventoryInput, Inventory>().ReverseMap();
                #endregion

                #region Customer
                mapper.CreateMap<CreateCustomerInput, Models.Customer>().ReverseMap();
                mapper.CreateMap<Models.Customer, GetCustomerOutput>().ReverseMap();
                mapper.CreateMap<UpdateCustomerInput, Models.Customer>().ReverseMap();
                mapper.CreateMap<Models.Customer, GetCustomerOutput>().ReverseMap();
                #endregion
            });
       


            


        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // TODO: Is there somewhere else to store these, with the dto classes
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Role and permission
                cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
                cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

                cfg.CreateMap<CreateRoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                cfg.CreateMap<RoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<CreateUserDto, User>();
                cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
            });
        }
    }
}
