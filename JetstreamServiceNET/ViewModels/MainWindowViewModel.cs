using System;
using System.Collections.ObjectModel;

namespace JetstreamServiceNET.ViewModels
{
	public class MainWindowViewModel
	{
		public ObservableCollection<User> Mitarbeiter { get; set; }

		public MainWindowViewModel()
		{
			Mitarbeiter = new ObservableCollection<User>
			{
				new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) },
				new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17) },
				new User() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) }
			};
		}
	}

}
