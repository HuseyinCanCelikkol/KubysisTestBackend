﻿using Common.Enums.DonationManagement;

namespace Common.DTOs.DonationManagement
{
    public record DonationUpdateDto(int Id,               
                                    string NameAndSurname,
                                    DonationType DonationType,
                                    DonationClass DonationClass, 
                                    int Amount,
                                    string PhoneNumber,
                                    DonationStatus DonationStatus);
}
