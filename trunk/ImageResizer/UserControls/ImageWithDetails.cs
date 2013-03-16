﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ImageResizer.UserControls {
  /// <summary>
  /// This is just a control with an image and a details pane below it.
  /// </summary>
  [DefaultEvent("Click")]
  public partial class ImageWithDetails : UserControl {
    #region props

    public new event EventHandler Click;

    [DefaultValue(PictureBoxSizeMode.Normal)]
    public PictureBoxSizeMode SizeMode {
      get { return (this.pbImage.SizeMode); }
      set { this.pbImage.SizeMode = value; }
    }

    [DefaultValue(null)]
    public Image Image {
      get { return (this.pbImage.Image); }
      set {
        this.pbImage.Image = value;
        if (value == null) {
          this.lDetails.Text = string.Empty;
          return;
        }

        var width = value.Width;
        var height = value.Height;
        this.lDetails.Text = string.Format("{0} x {1}", width, height);
      }
    }
    #endregion

    public ImageWithDetails() {
      InitializeComponent();
    }

    protected void _EventWrapper(object sender, EventArgs args) {
      this.OnClick(args);
    }

    protected new void OnClick(EventArgs e) {
      var handler = this.Click;
      if (handler != null)
        handler(this, e);
    }



  }
}