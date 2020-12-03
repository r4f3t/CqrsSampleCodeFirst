using AutoMapper;
using CqrsSampleFirst.Application.Common;
using CqrsSampleFirst.Domain.Test;

namespace CqrsSampleFirst.Application.Methods.TestMethod.Queries
{
    public class TestDto : IMapFrom<Test>
    {
        public string Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Test, TestDto>()
                .ForMember(d=>d.Value,opt=>opt.MapFrom(s=>s.Value+" "+s.Created.ToString()));
        }
    }
}
