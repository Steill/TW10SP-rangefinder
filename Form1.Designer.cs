namespace rangefinder
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comSelector = new System.Windows.Forms.ComboBox();
            this.measureBtn = new System.Windows.Forms.Button();
            this.outputList = new System.Windows.Forms.ListBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.btnLockTimer = new System.Windows.Forms.Timer(this.components);
            this.selectorLockTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // comSelector
            // 
            this.comSelector.FormattingEnabled = true;
            this.comSelector.Location = new System.Drawing.Point(12, 12);
            this.comSelector.Name = "comSelector";
            this.comSelector.Size = new System.Drawing.Size(95, 21);
            this.comSelector.TabIndex = 0;
            this.comSelector.Text = "Select COM";
            this.comSelector.DropDown += new System.EventHandler(this.RefreshCOMs);
            this.comSelector.SelectedIndexChanged += new System.EventHandler(this.ConnectToCOM);
            // 
            // measureBtn
            // 
            this.measureBtn.Enabled = false;
            this.measureBtn.Location = new System.Drawing.Point(12, 44);
            this.measureBtn.Name = "measureBtn";
            this.measureBtn.Size = new System.Drawing.Size(95, 23);
            this.measureBtn.TabIndex = 1;
            this.measureBtn.Text = "MEASURE";
            this.measureBtn.UseVisualStyleBackColor = true;
            this.measureBtn.Click += new System.EventHandler(this.SendCommand);
            // 
            // outputList
            // 
            this.outputList.FormattingEnabled = true;
            this.outputList.Location = new System.Drawing.Point(113, 12);
            this.outputList.Name = "outputList";
            this.outputList.Size = new System.Drawing.Size(360, 121);
            this.outputList.TabIndex = 2;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(12, 110);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(94, 23);
            this.clearBtn.TabIndex = 3;
            this.clearBtn.Text = "CLEAR";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.ClearOutput);
            // 
            // btnLockTimer
            // 
            this.btnLockTimer.Interval = 2500;
            this.btnLockTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // selectorLockTimer
            // 
            this.selectorLockTimer.Interval = 1000;
            this.selectorLockTimer.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 146);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.outputList);
            this.Controls.Add(this.measureBtn);
            this.Controls.Add(this.comSelector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "RangeFinder";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comSelector;
        private System.Windows.Forms.Button measureBtn;
        private System.Windows.Forms.ListBox outputList;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Timer btnLockTimer;
        private System.Windows.Forms.Timer selectorLockTimer;
    }
}

