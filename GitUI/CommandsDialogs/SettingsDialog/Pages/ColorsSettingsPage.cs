﻿using System;
using System.Linq;
using System.Windows.Forms;
using GitCommands;
using GitUI.Editor;

namespace GitUI.CommandsDialogs.SettingsDialog.Pages
{
    public partial class ColorsSettingsPage : SettingsPageWithHeader
    {
        public ColorsSettingsPage()
        {
            InitializeComponent();
            Text = "Colors";
            Translate();
        }

        protected override void OnRuntimeLoad()
        {
            base.OnRuntimeLoad();

            // align 1st columns across all tables
            tlpnlRevisionGraph.AdjustWidthToSize(0, MulticolorBranches, lblColorLineRemoved);
            tlpnlDiffView.AdjustWidthToSize(0, MulticolorBranches, lblColorLineRemoved);

            // align 2nd columns across all tables
            var colorControls = tlpnlRevisionGraph.Controls.Cast<Control>().Where(c => tlpnlRevisionGraph.GetColumn(c) == 1)
                .Union(tlpnlDiffView.Controls.Cast<Control>().Where(c => tlpnlDiffView.GetColumn(c) == 1))
                .ToArray();
            tlpnlRevisionGraph.AdjustWidthToSize(1, colorControls);
            tlpnlDiffView.AdjustWidthToSize(1, colorControls);
        }

        protected override void SettingsToPage()
        {
            MulticolorBranches.Checked = AppSettings.MulticolorBranches;
            MulticolorBranches_CheckedChanged(null, null);

            chkDrawAlternateBackColor.Checked = AppSettings.RevisionGraphDrawAlternateBackColor;
            DrawNonRelativesGray.Checked = AppSettings.RevisionGraphDrawNonRelativesGray;
            DrawNonRelativesTextGray.Checked = AppSettings.RevisionGraphDrawNonRelativesTextGray;
            BranchBorders.Checked = AppSettings.BranchBorders;
            StripedBanchChange.Checked = AppSettings.StripedBranchChange;
            HighlightAuthoredRevisions.Checked = AppSettings.HighlightAuthoredRevisions;

            _NO_TRANSLATE_ColorGraphLabel.BackColor = AppSettings.GraphColor;
            _NO_TRANSLATE_ColorGraphLabel.Text = AppSettings.GraphColor.Name;
            _NO_TRANSLATE_ColorGraphLabel.ForeColor = ColorHelper.GetForeColorForBackColor(_NO_TRANSLATE_ColorGraphLabel.BackColor);
            _NO_TRANSLATE_ColorTagLabel.BackColor = AppSettings.TagColor;
            _NO_TRANSLATE_ColorTagLabel.Text = AppSettings.TagColor.Name;
            _NO_TRANSLATE_ColorTagLabel.ForeColor = ColorHelper.GetForeColorForBackColor(_NO_TRANSLATE_ColorTagLabel.BackColor);
            _NO_TRANSLATE_ColorBranchLabel.BackColor = AppSettings.BranchColor;
            _NO_TRANSLATE_ColorBranchLabel.Text = AppSettings.BranchColor.Name;
            _NO_TRANSLATE_ColorBranchLabel.ForeColor = ColorHelper.GetForeColorForBackColor(_NO_TRANSLATE_ColorBranchLabel.BackColor);
            _NO_TRANSLATE_ColorRemoteBranchLabel.BackColor = AppSettings.RemoteBranchColor;
            _NO_TRANSLATE_ColorRemoteBranchLabel.Text = AppSettings.RemoteBranchColor.Name;
            _NO_TRANSLATE_ColorRemoteBranchLabel.ForeColor = ColorHelper.GetForeColorForBackColor(_NO_TRANSLATE_ColorRemoteBranchLabel.BackColor);
            _NO_TRANSLATE_ColorOtherLabel.BackColor = AppSettings.OtherTagColor;
            _NO_TRANSLATE_ColorOtherLabel.Text = AppSettings.OtherTagColor.Name;
            _NO_TRANSLATE_ColorOtherLabel.ForeColor = ColorHelper.GetForeColorForBackColor(_NO_TRANSLATE_ColorOtherLabel.BackColor);

            _NO_TRANSLATE_ColorAddedLineLabel.BackColor = AppSettings.DiffAddedColor;
            _NO_TRANSLATE_ColorAddedLineLabel.Text = AppSettings.DiffAddedColor.Name;
            _NO_TRANSLATE_ColorAddedLineLabel.ForeColor = ColorHelper.GetForeColorForBackColor(_NO_TRANSLATE_ColorAddedLineLabel.BackColor);
            _NO_TRANSLATE_ColorAddedLineDiffLabel.BackColor = AppSettings.DiffAddedExtraColor;
            _NO_TRANSLATE_ColorAddedLineDiffLabel.Text = AppSettings.DiffAddedExtraColor.Name;
            _NO_TRANSLATE_ColorAddedLineDiffLabel.ForeColor = ColorHelper.GetForeColorForBackColor(_NO_TRANSLATE_ColorAddedLineDiffLabel.BackColor);

            _NO_TRANSLATE_ColorRemovedLine.BackColor = AppSettings.DiffRemovedColor;
            _NO_TRANSLATE_ColorRemovedLine.Text = AppSettings.DiffRemovedColor.Name;
            _NO_TRANSLATE_ColorRemovedLine.ForeColor = ColorHelper.GetForeColorForBackColor(_NO_TRANSLATE_ColorRemovedLine.BackColor);
            _NO_TRANSLATE_ColorRemovedLineDiffLabel.BackColor = AppSettings.DiffRemovedExtraColor;
            _NO_TRANSLATE_ColorRemovedLineDiffLabel.Text = AppSettings.DiffRemovedExtraColor.Name;
            _NO_TRANSLATE_ColorRemovedLineDiffLabel.ForeColor = ColorHelper.GetForeColorForBackColor(_NO_TRANSLATE_ColorRemovedLineDiffLabel.BackColor);
            _NO_TRANSLATE_ColorSectionLabel.BackColor = AppSettings.DiffSectionColor;
            _NO_TRANSLATE_ColorSectionLabel.Text = AppSettings.DiffSectionColor.Name;
            _NO_TRANSLATE_ColorSectionLabel.ForeColor = ColorHelper.GetForeColorForBackColor(_NO_TRANSLATE_ColorSectionLabel.BackColor);

            _NO_TRANSLATE_ColorAuthoredRevisions.BackColor = AppSettings.AuthoredRevisionsColor;
            _NO_TRANSLATE_ColorAuthoredRevisions.Text = AppSettings.AuthoredRevisionsColor.Name;
            _NO_TRANSLATE_ColorAuthoredRevisions.ForeColor = ColorHelper.GetForeColorForBackColor(_NO_TRANSLATE_ColorAuthoredRevisions.BackColor);
        }

        protected override void PageToSettings()
        {
            AppSettings.MulticolorBranches = MulticolorBranches.Checked;
            AppSettings.RevisionGraphDrawAlternateBackColor = chkDrawAlternateBackColor.Checked;
            AppSettings.RevisionGraphDrawNonRelativesGray = DrawNonRelativesGray.Checked;
            AppSettings.RevisionGraphDrawNonRelativesTextGray = DrawNonRelativesTextGray.Checked;
            AppSettings.BranchBorders = BranchBorders.Checked;
            AppSettings.StripedBranchChange = StripedBanchChange.Checked;
            AppSettings.HighlightAuthoredRevisions = HighlightAuthoredRevisions.Checked;

            AppSettings.GraphColor = _NO_TRANSLATE_ColorGraphLabel.BackColor;
            AppSettings.TagColor = _NO_TRANSLATE_ColorTagLabel.BackColor;
            AppSettings.BranchColor = _NO_TRANSLATE_ColorBranchLabel.BackColor;
            AppSettings.RemoteBranchColor = _NO_TRANSLATE_ColorRemoteBranchLabel.BackColor;
            AppSettings.OtherTagColor = _NO_TRANSLATE_ColorOtherLabel.BackColor;
            AppSettings.AuthoredRevisionsColor = _NO_TRANSLATE_ColorAuthoredRevisions.BackColor;

            AppSettings.DiffAddedColor = _NO_TRANSLATE_ColorAddedLineLabel.BackColor;
            AppSettings.DiffRemovedColor = _NO_TRANSLATE_ColorRemovedLine.BackColor;
            AppSettings.DiffAddedExtraColor = _NO_TRANSLATE_ColorAddedLineDiffLabel.BackColor;
            AppSettings.DiffRemovedExtraColor = _NO_TRANSLATE_ColorRemovedLineDiffLabel.BackColor;
            AppSettings.DiffSectionColor = _NO_TRANSLATE_ColorSectionLabel.BackColor;
        }

        private void MulticolorBranches_CheckedChanged(object sender, EventArgs e)
        {
            if (MulticolorBranches.Checked)
            {
                _NO_TRANSLATE_ColorGraphLabel.Visible = false;
                StripedBanchChange.Enabled = true;
            }
            else
            {
                _NO_TRANSLATE_ColorGraphLabel.Visible = true;
                StripedBanchChange.Enabled = false;
            }
        }

        private void ColorLabel_Click(object sender, EventArgs e)
        {
            PickColor((Label)sender);
        }

        private void PickColor(Control targetColorControl)
        {
            using (var colorDialog = new ColorDialog { Color = targetColorControl.BackColor })
            {
                colorDialog.ShowDialog(this);
                targetColorControl.BackColor = colorDialog.Color;
                targetColorControl.Text = colorDialog.Color.Name;
            }

            targetColorControl.ForeColor =
                ColorHelper.GetForeColorForBackColor(targetColorControl.BackColor);
        }
    }
}
