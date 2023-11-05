using System;
using System.Collections.Generic;

namespace ProjektKCK
{ 
    class Inventory
    {
        private List<Note> notes; 
        public Inventory()
        {
            notes = new List<Note>();
        }

        public void AddNote(Note note)
        {
            notes.Add(note);
        }

        public void RemoveNote(Note note)
        {
            notes.Remove(note);
        }

        public void DisplayNotes()
        {
            List<string> options = new List<string>();
            UI.CenterAsci("Player's Notes:");
            foreach (Note note in notes)
            {
                options.Add(note.Title);
                options.Add(note.Content);
            }
            UI.DisplayMenu(options);
        }
        public bool HasNote(string title)
        {
            foreach (Note note in notes)
            {
                if (note.Title == title)
                    return true;
            }
            return false;
        }
        public int HowManyNotes()
        {
            int count = 0;
            foreach(Note note in notes)
            {
                count ++;
            }
            return count;
        }
    }
}