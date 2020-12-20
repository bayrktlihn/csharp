using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TenFinger
{
    public partial class MainForm : Form
    {
        private Queue<String> _words = new Queue<string>();
        private int _corretWordCount;
        private int _wrongWordCount;




        public MainForm()
        {
            InitializeComponent();

            LoadWords();
        }

        private void Reset()
        {
            _corretWordCount = 0;
            _wrongWordCount = 0;

            LoadWords();

            wordTextBox.Enabled = true;
            startButton.Enabled = false;

            currentWordLabel.Text = _words.Peek();
        }

        private void LoadWords()
        {
            _words.Clear();

            String text = @"
            the enterprise centre has an important role in the pathogenesis of acute pancreatitis in fine form and the consequent conservative government since 1979 the government has published a document in the new system will be installed at the company's headquarters in new york and scarborough and filey of regent's park, london and basingstoke, macmillan conference, at the very last minute en equally unsuccessfully competent in the use of the mental element in the `new species and nancial problems are also available for the taking.
            ".Trim().ClearPunctuation();

            String[] words = text.Split(' ');


            words = ShuffleWords(words);



            foreach (String word in words)
            {
                _words.Enqueue(word);
            }

        }

        private String[] ShuffleWords(string[] words)
        {
            Random random = new Random();
            String [] result = words.OrderBy(p => random.NextDouble()).ToArray();

            return result;
        }

        

        private void startButton_Click(object sender, EventArgs e)
        {
            Reset();


            Thread t = new Thread(() => {
                for (int i = 0; i < 60; i++)
                {
                    Thread.Sleep(1000);
                    timeLabel.Text = "" + (i + 1);


                }

                wordTextBox.Enabled = false;
                startButton.Enabled = true;

                currentWordLabel.Text = "";
                timeLabel.Text = "";

                wordTextBox.Text = "";
                MessageBox.Show($"Correct Word Count: {_corretWordCount}, Wrond Word Count: {_wrongWordCount}", "Information");
            });

            t.IsBackground = true;

            t.Start();

        }



        private void wordTextBox_TextChanged(object sender, EventArgs e)
        {
            String enteredWord = wordTextBox.Text;


            if (enteredWord != null && enteredWord != "")
            {

                if (enteredWord[enteredWord.Length - 1] == ' ')
                {
                    enteredWord = enteredWord.Trim();
                    String currentWord = _words.Dequeue();


                    if (currentWord == enteredWord) {
                        _corretWordCount++;
                    }
                    else
                    {
                        _wrongWordCount++;
                    }

                    wordTextBox.Text = "";

                    currentWordLabel.Text = _words.Peek();

                }

            }
        }
    }

    public static class MyStringExtensionMethods{
        public static String ClearPunctuation(this String word)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char letter in word)
            {
                if (!char.IsPunctuation(letter))
                {
                    sb.Append(letter);
                }
            }

            return sb.ToString();
        }
    }
}
