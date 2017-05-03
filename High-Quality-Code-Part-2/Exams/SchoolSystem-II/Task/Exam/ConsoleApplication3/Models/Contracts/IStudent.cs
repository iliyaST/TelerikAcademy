﻿namespace SchoolSystem.CLI.Models.Contracts
{
    using System.Collections.Generic;
    using Enums;

    /// <summary>
    /// Represens a Student and extends a Person, has a Grade, a collection of Marks and a way of displaying those marks.
    /// </summary>
    public interface IStudent : IPerson
    {
        Grade Grade { get; set; }

        IList<IMark> Marks { get; }

        /// <summary>
        /// Generates a list of the student's marks in a specific format.
        /// </summary>
        /// <returns>Returns a string, formatted as a list of marks. If there are no marks, it returns an appropriate error message.</returns>
        string ListMarks();
    }
}
