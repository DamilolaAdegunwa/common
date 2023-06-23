using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseApp.ConsoleApp.Algorithms
{
public class Operation
	{
		public int Position { get; }
		public string Text { get; }

		public Operation(int position, string text)
		{
			Position = position;
			Text = text;
		}
	}

	public class TextEditor
	{
		private string text;
		private List<Operation> history;

		public TextEditor(string initialText)
		{
			text = initialText;
			history = new List<Operation>();
		}

		public void Insert(int position, string newText)
		{
			// Create an operation for the insertion
			Operation operation = new Operation(position, newText);

			// Apply the operation to the text
			text = ApplyOperation(text, operation);

			// Add the operation to the history
			history.Add(operation);
		}

		public void Delete(int position, int length)
		{
			// Create an operation for the deletion
			Operation operation = new Operation(position, "");

			// Apply the operation to the text
			text = ApplyOperation(text, operation);

			// Add the operation to the history
			history.Add(operation);
		}

		public void Undo()
		{
			if (history.Count == 0)
			{
				Console.WriteLine("Nothing to undo.");
				return;
			}

			// Get the last operation from the history
			Operation lastOperation = history[history.Count - 1];

			// Invert the operation
			Operation invertedOperation = InvertOperation(lastOperation);

			// Apply the inverted operation to the text
			text = ApplyOperation(text, invertedOperation);

			// Remove the last operation from the history
			history.RemoveAt(history.Count - 1);
		}

		public string GetText()
		{
			return text;
		}

		private string ApplyOperation(string text, Operation operation)
		{
			// Split the text into two parts: before the insertion/deletion position and after
			string before = text.Substring(0, operation.Position);
			string after = text.Substring(operation.Position);

			// Apply the operation by concatenating the before part, the operation text, and the after part
			return before + operation.Text + after;
		}

		private Operation InvertOperation(Operation operation)
		{
			// For an insertion operation, create a deletion operation with the same position and text length
			// For a deletion operation, create an insertion operation with the same position and the deleted text
			if (operation.Text.Length > 0)
			{
				return new Operation(operation.Position, "");
			}
			else
			{
				string deletedText = text.Substring(operation.Position, -operation.Text.Length);
				return new Operation(operation.Position, deletedText);
			}
		}
	}

	public class Program_OperationalTransformer
	{
		public static void Main_Program_OperationalTransformer(string[] args)
		{
			// Create a text editor with an initial text
			TextEditor editor = new TextEditor("Hello, world!");

			// Insert text at a specific position
			editor.Insert(7, "there ");
			Console.WriteLine(editor.GetText());  // Output: Hello, there world!

			// Delete text at a specific position
			editor.Delete(5, 5);
			Console.WriteLine(editor.GetText());  // Output: Hello world!

			// Undo the last operation
			editor.Undo();
			Console.WriteLine(editor.GetText());  // Output: Hello, there world!
		}
	}

}
