﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseHub.Infrastructure.Data.Constants
{
    public class DataConstants
    {
        public const int CategoryNameMaxLength = 50;

        public const int CategoryNameMinLength = 5;

        public const int CourseNameMaxLength = 50;

        public const int CourseNameMinLength = 5;

        public const int CourseDescriptionMaxLength = 500;

        public const int CourseDescriptionMinLength = 0;

        public const int CourseMaxFrequency = 7;

        public const int CourseMinFrequency = 1;

        public const int CityNameMaxLength = 50;

        public const int CityNameMinLength = 3;

        public const string CourseMinPrice = "0";

        public const string CourseMaxPrice = "5000";

        public const int TeacherPhoneNumberMaxLength = 13;

        public const int TeacherPhoneNumberMinLength = 7;

        public const string DateFormat = "dd/MM/yyyy";

		public const int UserFirstNameMaxLength = 20;

		public const int UserFirstNameMinLength = 1;

		public const int UserLastNameMaxLength = 15;

		public const int UserLastNameMinLength = 3;

		public const int ReviewCommentsMinLength = 0;

		public const int ReviewCommentsMaxLength = 300;

		public const int ReviewMinRating = 1;

		public const int ReviewMaxRating = 5;

        public const int ResultFeedbackMinLength = 10;

        public const int ResultFeedbackMaxLength = 300;

        public const int ResultMinGrade = 2;

        public const int ResultMaxGrade = 6;
	}
}
