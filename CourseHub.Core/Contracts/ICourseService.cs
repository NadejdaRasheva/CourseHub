﻿using CourseHub.Core.Enumerations;
using CourseHub.Core.Models.Course;

namespace CourseHub.Core.Contracts
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseCategoryServiceModel>> AllCategoriesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> CreateAsync(string name, string description,
            DateTime startDate, DateTime endDate, int frequency,
            decimal price, int categoryId, int teacherId);

        Task<CourseQueryServiceModel> AllAsync(string? category = null,
            string? searchTerm = null,
            CourseSorting sorting = CourseSorting.Newest,
            CourseFiltering filtering = CourseFiltering.All,
            int currentPage = 1,
            int coursesPerPage = 1);

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task<IEnumerable<CourseServiceModel>> AllCoursesByTeacherIdAsync(int teacherId);

        Task<IEnumerable<CourseServiceModel>> AllCoursesByUserIdAsync(string userId);
    }
}