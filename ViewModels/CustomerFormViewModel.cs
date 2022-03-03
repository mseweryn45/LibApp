﻿using System;
using LibApp.Dtos;
using LibApp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibApp.ViewModels
{
    public class CustomerFormViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide customer's name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool HasNewsletterSubscribed { get; set; }
        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Please provide Membership Type")]
        public byte? MembershipTypeId { get; set; }
        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }
        public IEnumerable<MembershipTypeDto> MembershipTypes { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Customer" : "New Customer";
            }
        }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(CustomerDto customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            MembershipTypeId = customer.MembershipTypeId;
            HasNewsletterSubscribed = customer.HasNewsletterSubscribed;
            Birthdate = customer.Birthdate;
        }
    }
}
