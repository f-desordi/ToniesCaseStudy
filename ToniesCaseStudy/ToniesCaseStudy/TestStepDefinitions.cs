using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestEngine;

namespace ToniesCaseStudy
{
    internal partial class Program
    {

        private static TestStepCollection TestStepDefinitions = new TestStepCollection()
        {
            new InputTestStep()   { Name = "ID_1.1_Input_Valid_Pattern_HH:MM",   Input = "1230", EntryExpected = "12:30",    LabelExpected = "" },
            new ConfirmTestStep() { Name = "ID_1.1_Confirm_Valid_Pattern_HH:MM",                 EntryExpected = "12:30",    LabelExpected = "12:30" },

            new InputTestStep()   { Name = "ID_1.2_Input_Valid_Pattern_1:MM",    Input = "1:30", EntryExpected = "1:30",     LabelExpected = "12:30" },
            new ConfirmTestStep() { Name = "ID_1.2_Confirm_Valid_Pattern_1:MM",                  EntryExpected = "1:30",     LabelExpected = "1:30" },

            new InputTestStep()   { Name = "ID_1.3_Input_Valid_Pattern_2:MM",    Input = "2:30", EntryExpected = "2:30",     LabelExpected = "1:30" },
            new ConfirmTestStep() { Name = "ID_1.3_Confirm_Valid_Pattern_2:MM",                  EntryExpected = "2:30",     LabelExpected = "2:30" },

            new InputTestStep()   { Name = "ID_1.4_Input_Valid_Pattern_H:MM",    Input = "830",  EntryExpected = "8:30",     LabelExpected = "2:30" },
            new ConfirmTestStep() { Name = "ID_1.4_Confirm_Valid_Pattern_H:MM",                  EntryExpected = "8:30",     LabelExpected = "8:30" },

            new InputTestStep()   { Name = "ID_4.1_Input_Empty",                 Input = "",     EntryExpected = "",         LabelExpected = "8:30" },
            new ConfirmTestStep() { Name = "ID_4.1_Confirm_Empty",                               EntryExpected = "",         LabelExpected = "" },

            new InputTestStep()   { Name = "ID_2.1_Input_Invalid_Letter",        Input = "A",    EntryExpected = "",         LabelExpected = "" },
            
            new InputTestStep()   { Name = "ID_2.2_Input_Invalid_Time",          Input = "2576", EntryExpected = "2",        LabelExpected = "" },

            new ConfirmTestStep() { Name = "ID_3.1_Confirm_Invalid_Time_H",                      EntryExpected = "2",        LabelExpected = "" },

            new InputTestStep()   { Name = "ID_3.2_Input_Invalid_Time_H:",       Input = "3",    EntryExpected = "3:",       LabelExpected = "" },
            new ConfirmTestStep() { Name = "ID_3.2_Confirm_Invalid_Time_H:",                     EntryExpected = "3:",       LabelExpected = "" },

            new InputTestStep()   { Name = "ID_3.3_Input_Invalid_Time_HH:",      Input = "12",   EntryExpected = "12:",      LabelExpected = "" },
            new ConfirmTestStep() { Name = "ID_3.3_Confirm_Invalid_Time_HH:",                    EntryExpected = "12:",      LabelExpected = "" },

            new InputTestStep()   { Name = "ID_3.4_Input_Invalid_Time_H:M",      Input = "33",   EntryExpected = "3:3",      LabelExpected = "" },
            new ConfirmTestStep() { Name = "ID_3.4_Confirm_Invalid_Time_H:M",                    EntryExpected = "3:3",      LabelExpected = "" },

            new InputTestStep()   { Name = "ID_3.5_Input_Invalid_Time_HH:M",     Input = "123",  EntryExpected = "12:3",     LabelExpected = "" },
            new ConfirmTestStep() { Name = "ID_3.5_Confirm_Invalid_Time_HH:M",                   EntryExpected = "12:3",     LabelExpected = "" },
        };
    }
}
