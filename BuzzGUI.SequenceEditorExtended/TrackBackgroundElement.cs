﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using BuzzGUI.Interfaces;

namespace BuzzGUI.SequenceEditor
{
	public class TrackBackgroundElement : FrameworkElement
	{


		ViewSettings viewSettings;
		public ViewSettings ViewSettings
		{
			set
			{
				viewSettings = value;
				InvalidateMeasure();
			}

		}

		protected override Size MeasureOverride(Size availableSize)
		{
			return new Size(viewSettings.Width, availableSize.Height == double.PositiveInfinity ? 0 : availableSize.Height);
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			return finalSize;
		}

		protected override void OnRender(DrawingContext dc)
		{
			if (viewSettings == null) return;
			var tbr = TryFindResource("SeqEdTimelineTextBrush") as Brush;
			var lbr = TryFindResource("SeqEdTimelineLineBrush") as Brush;

			foreach (var bar in viewSettings.TimeSignatureList.GetBars(viewSettings.SongEnd))
			{
				double x = bar.Item1 * viewSettings.TickWidth;
				double w = bar.Item2 * viewSettings.TickWidth;

				if (x > 0) dc.DrawRectangle(lbr, null, new Rect(x, 0, 1, ActualHeight));

			}

			dc.DrawRectangle(lbr, null, new Rect(viewSettings.SongEnd * viewSettings.TickWidth, 0, 1, ActualHeight));


		}
	}
}
