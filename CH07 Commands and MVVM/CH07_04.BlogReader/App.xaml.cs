using CH07_04.BlogReader.Models;
using CH07_04.BlogReader.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CH07_04.BlogReader
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var stream = new FileStream("Images/blogger.jpg", FileMode.Open);
            var blogs = new ObservableCollection<Blog>
            {
                new Blog
                {
                    Blogger=new Blogger {
                        Name="Bart Simpson",
                        Email="zer@springfield.com",
                        Picture=stream// GetResourceStream(new Uri("C:/Users/kraph/Github/WPF_RecipeBook/blogger.jpg", UriKind.Absolute)).Stream
                    },
                    BlogTitle="Bart's adventure",
                    Posts =
                    {
                        new BlogPost
                        {
                            When=new DateTime(2000,8,12),
                            Title="Post 1",
                            Text="This is the firt post of Bart",
                            Comments =
                            {
                                new BlogComment
                                {
                                    Name="Home S.",
                                    Text="Why you little...",
                                    When=new DateTime(2000,8,13),
                                }
                            }
                        },
                        new BlogPost
                        {
                            When=new DateTime(2002,3,22),
                            Title="Post 2",
                            Text="This is the seconde post of Bart",
                            Comments =
                            {
                                new BlogComment
                                {
                                    Name="Lisa S.",
                                    Text="Come on Bart!",
                                    When=new DateTime(2002,3,24),
                                },
                                new BlogComment
                                {
                                    Name="Maggie S.",
                                    Text="Whaaaa!",
                                    When=DateTime.Now,
                                }
                            }
                        }
                    }
                }
            };

            var vm = new MainVM(blogs);
            var win = new MainWindow { DataContext = vm, Title="FOO" };
            win.Show();
        }
    }
}
