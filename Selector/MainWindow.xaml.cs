using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace Selector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static string filePath = Directory.GetCurrentDirectory() + "\\Studenten.txt";

        List<Student> students = new List<Student>();
        List<Student> group = new List<Student>();

        List<string> lines = File.ReadAllLines(filePath).ToList();

        public MainWindow()
        {
            InitializeComponent();
            BindStudentList();
        }

        private void BindStudentList()
        {
            lstAllStudents.Items.Clear();

            foreach (string line in lines)
            {
                string[] entries = line.Split(';');

                Student student = new Student();
                student.Level = int.Parse(entries[0]);
                student.FirstName = entries[1];
                student.LastName = entries[2];

                students.Add(student);
            }
            foreach (Student student in students)
            {
                lstAllStudents.Items.Add(student);
            }
        }

        private void StudentItemsAdd()
        {
            lstAllStudents.Items.Clear();
            foreach (Student student in students)
            {
                lstAllStudents.Items.Add(student);
            }
        }

        private void GroupsItemsAdd()
        {
            lstGroup.Items.Clear();
            foreach (var student in group)
            {
                lstGroup.Items.Add(student);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FirstMethod();
            SecondMethod();
            StudentItemsAdd();
            group.Clear();
        }
   
        private void FirstMethod()
        {
            var rnd = new Random();
            var index = 0;
            Student newGroup = new Student();
            foreach (Student item in students)
            {
                index = rnd.Next(0, students.Count);
                if (students[index].Level == 1)
                {
                    newGroup = students[index];
                    group.Add(newGroup);
                    students.RemoveAt(index);

                    StudentItemsAdd();
                    GroupsItemsAdd();
                    return;
                }
                else
                    continue;
            }
        }
        private void SecondMethod()
        {
            var rnd = new Random();
            var index = 0;
            int i = 0;
            while (i < int.Parse(txtCount.Text)-1)
            {
                index = rnd.Next(0, students.Count);
                if (students[index].Level > 1)
                {
                    Student newGroup = new Student();
                    newGroup = students[index];
                    group.Add(newGroup);
                    students.RemoveAt(index);

                    StudentItemsAdd();
                    GroupsItemsAdd();
                    
                        i++;
                }
                else
                    continue;
            }

        }
    }
}
