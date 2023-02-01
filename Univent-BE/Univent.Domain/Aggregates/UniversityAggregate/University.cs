﻿using Univent.Domain.Aggregates.UserAggregate;

namespace Univent.Domain.Aggregates.UniversityAggregate
{
    public class University
    {
        public Guid UniversityID { get; private set; }
        private readonly List<UserProfile> _users = new List<UserProfile>();
        public IEnumerable<UserProfile> UserProfiles { get { return _users; } }
        public string Name { get; private set; }

        //Constructor
        private University()
        {
        }

        //Factory method
        public static University CreateUniversity(string name)
        {
            //TO DO: add validation and error handling
            var newUniversity = new University
            {
                Name = name
            };

            return newUniversity;
        }
    }
}