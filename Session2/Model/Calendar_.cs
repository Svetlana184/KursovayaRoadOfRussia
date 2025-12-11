using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Desktop.Model;

public partial class Calendar_ :  INotifyPropertyChanged, IComparable<Calendar_>
{
    
    public int IdCalendar
    {
        get;
        set;
    }
    private int? idemployee;
    public int? IdEmployee 
    { 
        get {  return idemployee; }
        set
        {
            idemployee = value;
            OnPropertyChanged(nameof(IdEmployee));
        }
    }
    private string typeofevent;
    public string TypeOfEvent
    {
        get { return typeofevent; }
        set { typeofevent = value; OnPropertyChanged(nameof(TypeOfEvent)); }
    }
    private int? idevent;
    public int? IdEvent
    {
        get
        {
            if (idevent != null) return idevent;
            else return null;
        }
        set { idevent = value; OnPropertyChanged(nameof(IdEvent)); }
    }

    private string? typeofabsence;
    public string? TypeOfAbsense
    {
        get { return typeofabsence; }
        set { typeofabsence = value; OnPropertyChanged(nameof(TypeOfAbsense)); }
    }
    private int? idalternate;
    public int? IdAlternate
    {
        get
        {
            if (idalternate != null) return idalternate;
            else return null;
        }
        set { idalternate = value; OnPropertyChanged(nameof(IdAlternate)); }
    }
    private DateOnly datestart;
    public DateOnly DateStart
    {
        get
        {
            return datestart;

        }
        set
        {
            datestart = value;
            OnPropertyChanged(nameof(DateStart));
        }
    }
    private DateOnly datefinish;
    public DateOnly DateFinish
    {
        get
        {
           return datefinish;
        }
        set
        {
            datefinish = value;
            OnPropertyChanged(nameof(DateFinish));
        }
    }

   

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    public int CompareTo(Calendar_? obj)
    {
        if (obj is Calendar_)
        {
            Calendar_ obj1 = obj as Calendar_;
            return (this.DateStart.CompareTo(obj1!.DateStart));
        }
        return 0;
    }
}
