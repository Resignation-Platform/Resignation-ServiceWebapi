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

            CreateMap<EmployeeExitDetailsViewModel, EmployeeExitDetails>()
                .ForMember(dest => dest.txtEmployeeNumber, opt => opt.MapFrom(src => src.EmployeeNumber))
                .ForMember(dest => dest.txtEmpMailId, opt => opt.MapFrom(src => src.MailId))
                .ForMember(dest => dest.txtEmpPersonalEmailid, opt => opt.MapFrom(src => src.PersonalEmailId))
                .ForMember(dest => dest.txtEmpContact, opt => opt.MapFrom(src => src.ContactNumber))
                .ForMember(dest => dest.dtSeparationDate, opt => opt.MapFrom(src => src.SeparationDate))
                .ForMember(dest => dest.dtLastWorkingDate, opt => opt.MapFrom(src => src.LastWorkingDay))
                ;
            CreateMap<EmployeeExit,EmployeeExitViewModel>()
                .ForMember(dest => dest.EmployeeNumber, opt => opt.MapFrom(src => src.txtEmpNo))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.txtEmpId))
                .ForMember(dest => dest.PersonalEmail, opt => opt.MapFrom(src => src.txtEmpPersonalId))
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.txtcontact))
                .ForMember(dest => dest.SeparationDate, opt => opt.MapFrom(src => src.dtSeperationdate))
                .ForMember(dest => dest.LastWorkingDate, opt => opt.MapFrom(src => src.dtLastWorkingDate))
                .ForMember(dest => dest.IsHRApproved, opt => opt.MapFrom(src => src.flgIsHrApproved == "1" ? true : false))
                .ForMember(dest => dest.IsPMApproved, opt => opt.MapFrom(src => src.flgIsPmApproed == "1" ? true : false))
                .ForMember(dest => dest.IsDHApproved, opt => opt.MapFrom(src => src.flgisDHApproved == "1" ? true : false))
                .ForMember(dest => dest.ITClearance, opt => opt.MapFrom(src => src.flgITClearance == "1" ? true : false))
                .ForMember(dest => dest.FinanceClearance, opt => opt.MapFrom(src => src.flgFinanceClearance == "1" ? true : false))
                .ReverseMap();

            CreateMap<AdminDetails, AdminDetailsViewModel>()
                .ForMember(dest => dest.EmployeeNo, opt => opt.MapFrom(src => src.txtEmployeeNo))
                .ForMember(dest => dest.EmployeeEmailId, opt => opt.MapFrom(src => src.txtEmpEmailId))
                .ForMember(dest => dest.EmployeePersonalEmailid, opt => opt.MapFrom(src => src.txtEmpPersonalEmailid))
                .ForMember(dest => dest.EmployeeContact, opt => opt.MapFrom(src => src.txtEmpContact))
                .ForMember(dest => dest.SeperationDate, opt => opt.MapFrom(src => src.dtSeperationDate))
                .ForMember(dest => dest.LastWorkingDate, opt => opt.MapFrom(src => src.dtLastWorkingDate));

            CreateMap<ExitFeedbackViewModel, ExitFeedback>()
                .ForMember(dest => dest.txtQuestion, opt => opt.MapFrom(src => src.Question))
                .ForMember(dest => dest.txtAnswer, opt => opt.MapFrom(src => src.Answer));
        }
    }
}
