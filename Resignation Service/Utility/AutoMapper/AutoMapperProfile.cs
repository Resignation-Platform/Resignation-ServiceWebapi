using AutoMapper;
using Resignation_Service.Models;
using Resignation_Service.ViewModels;

namespace Resignation_Service.Utility.AutoMapper
{
    /// <summary>
    /// Auto mapper profile class
    /// </summary>
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(dest => dest.EmployeeNumber, opt => opt.MapFrom(src => src.txtEmpNo))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.txtEmpMailId))
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.txtEmpRole))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.txtDeptName))
                .ForMember(dest => dest.DateOfJoining, opt => opt.MapFrom(src => src.dtDateOfJoining))
                .ForMember(dest => dest.HRName, opt => opt.MapFrom(src => src.txtHR))
                .ForMember(dest => dest.ProgramManagerName, opt => opt.MapFrom(src => src.txtProgramManager))
                .ForMember(dest => dest.DeliveryLeaderName, opt => opt.MapFrom(src => src.txtDeliveryHead));
            
            CreateMap<Feedback, FeedbackViewModel>()
                .ForMember(dest => dest.FeedbackId, opt => opt.MapFrom(src => src.intId))
                .ForMember(dest => dest.FeedbackQuestion, opt => opt.MapFrom(src => src.txtQuestion))
                .ForMember(dest => dest.Options, opt => opt.MapFrom(src => src.txtOptions));

            CreateMap<EmployeeExitViewModel, EmployeeExit>()
                .ForMember(dest => dest.txtEmployeeNumber, opt => opt.MapFrom(src => src.EmployeeNumber))
                .ForMember(dest => dest.txtEmpMailId, opt => opt.MapFrom(src => src.MailId))
                .ForMember(dest => dest.txtEmpPersonalEmailid, opt => opt.MapFrom(src => src.PersonalEmailId))
                .ForMember(dest => dest.txtEmpContact, opt => opt.MapFrom(src => src.ContactNumber))
                .ForMember(dest => dest.dtSeparationDate, opt => opt.MapFrom(src => src.SeparationDate))
                .ForMember(dest => dest.dtLastWorkingDate, opt => opt.MapFrom(src => src.LastWorkingDay));

            CreateMap<AdminDetails, AdminDetailsViewModel>()
                .ForMember(dest => dest.EmployeeNo, opt => opt.MapFrom(src => src.txtEmployeeNo))
                .ForMember(dest => dest.EmployeeEmailId, opt => opt.MapFrom(src => src.txtEmpEmailId))
                .ForMember(dest => dest.EmployeePersonalEmailid, opt => opt.MapFrom(src => src.txtEmpPersonalEmailid))
                .ForMember(dest => dest.EmployeeContact, opt => opt.MapFrom(src => src.txtEmpContact))
                .ForMember(dest => dest.SeperationDate, opt => opt.MapFrom(src => src.dtSeperationDate))
                .ForMember(dest => dest.LastWorkingDate, opt => opt.MapFrom(src => src.dtLastWorkingDate));
        }
    }
}
