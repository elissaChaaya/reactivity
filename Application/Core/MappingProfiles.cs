using System;
using AutoMapper;

namespace Application.Core;

public class MappingProfiles : Profile //profile clas we get form automapper
{
 public MappingProfiles()
 {
    CreateMap<Domain.Activity, Domain.Activity>(); //maps from Activity to Activity
 }
}
