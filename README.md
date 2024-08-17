# EvolveVirtualPhone
A simple C# project which looks exactly like a phone's screen with default apps on it.

It is created out of the following:
-------- PhoneVM
    |
    |
    |---- Controller
        |
        |-- ModelController.cs
            ** This class controlls the models. It reads from the Database folder and then creates an array of the model that each file rerpresents
        |-- WindowPropterties.cs
            ** This class has three methods in it. These are to controll closing, minimizing and maximising the window

    |---- Core
        |
        |-- ObservableObject

    |---- Database
        |-- Member.txt 
            /* --- member_id, first name, last name, email, password, date joined, has admin rights --- */
        |-- Message.txt
            /* --- member_id, message, time of message --- */
        |-- Todo.txt
            /* --- reminder --- */
    |---- Images
    |
    |---- Model
        |-- Member.cs
        |-- Message.cs
        |-- Todo.cs
    |
    |---- obj
    |
    |---- Properties
    |
    |---- Theme
        |-- Appstyle.xaml       (Styling the app icons in MainWindow)
        |-- calculator_button   (Styling the button in the CalculatorWindow)
        |-- RadioButtonStyle    (Styling the radio buttons in the TodoWindow)
        |-- WindowControlButton (Styling the minimise, maximise and close button at the top of each window)
    |---- View
        |---- MainWindow
            |---- calculator_container.xaml
                |-- calculator_container.cs
            |---- discord_container.xaml
                |-- discord_container.cs
            |---- messenger_container.xaml
                |-- messenger_container.cs
            |---- todo_container.xaml
                |-- todo_container.cs
    |---- ViewModel
        |---- MainWindow
            |-- CalculatorVM.cs
            |-- DiscordVM.cs
            |-- MessengerVM.cs
            |-- TodoVM.cs
        |-- HomeViewModel.cs
    |-- App.config
    |-- App.xaml
    |---- CalculatorWindow.xaml
        |-- CalculatorWindow.cs
    |---- MainWindow.xaml
        |-- MainWindow.cs
    |---- MessengerWindow.xaml
        |-- MessengerWindow.cs
    |---- TodoWindow.xaml
        |-- TodoWindow.cs
    
