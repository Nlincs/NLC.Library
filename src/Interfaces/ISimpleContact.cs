namespace NLC.Library.Interfaces
{
        /// <summary>
        ///     simple contact details
        /// </summary>
        public interface ISimpleContact
            {
                /// <summary>
                ///     Person
                /// </summary>
                IPerson Person { get; set; }

                /// <summary>
                ///     Address detail, this only includes things like uprn, usrn, full address etc
                /// </summary>
                ILocation Address { get; set; }

                /// <summary>
                ///     Preferred phone number
                /// </summary>
                ITelephoneNumber PreferredPhone { get; set; }

                /// <summary>
                ///     Home phone
                /// </summary>
                ITelephoneNumber HomePhone { get; set; }

                /// <summary>
                ///     Mobile phone
                /// </summary>
                ITelephoneNumber MobilePhone { get; set; }

                /// <summary>
                ///     Work phone
                /// </summary>
                ITelephoneNumber WorkPhone { get; set; }

                /// <summary>
                ///     email address
                /// </summary>
                string emailAddress { get; set; }

                /// <summary>
                ///     Notes
                /// </summary>
                string Notes { get; set; }
            }
}
