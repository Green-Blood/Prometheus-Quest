﻿using MoreMountains.Tools;
using UnityEngine;
using TMPro;

namespace MoreMountains.Feedbacks
{
    /// <summary>
    /// This feedback lets you control the character spacing of a target TMP over time
    /// </summary>
    [AddComponentMenu("")]
    [FeedbackHelp("This feedback lets you control the character spacing of a target TMP over time.")]
    [FeedbackPath("TextMesh Pro/TMP Character Spacing")]
    public class MMF_TMPCharacterSpacing : MMF_FeedbackBase
    {
        /// sets the inspector color for this feedback
        #if UNITY_EDITOR
            public override Color FeedbackColor { get { return MMFeedbacksInspectorColors.TMPColor; } }
            public override bool EvaluateRequiresSetup() { return (TargetTMPText == null); }
            public override string RequiredTargetText { get { return TargetTMPText != null ? TargetTMPText.name : "";  } }
            public override string RequiresSetupText { get { return "This feedback requires that a TargetTMPText be set to be able to work properly. You can set one below."; } }
        #endif

        [MMFInspectorGroup("Target", true, 12, true)]
        /// the TMP_Text component to control
        [Tooltip("the TMP_Text component to control")]
        public TMP_Text TargetTMPText;

        [MMFInspectorGroup("Character Spacing", true, 16)]
        /// the curve to tween on
        [Tooltip("the curve to tween on")]
        [MMFEnumCondition("Mode", (int)MMFeedbackBase.Modes.OverTime)]
        public MMTweenType CharacterSpacingCurve = new MMTweenType(new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.3f, 1f), new Keyframe(1, 0)));
        /// the value to remap the curve's 0 to
        [Tooltip("the value to remap the curve's 0 to")]
        [MMFEnumCondition("Mode", (int)MMFeedbackBase.Modes.OverTime)]
        public float RemapZero = 0f;
        /// the value to remap the curve's 1 to
        [Tooltip("the value to remap the curve's 1 to")]
        [MMFEnumCondition("Mode", (int)MMFeedbackBase.Modes.OverTime)]
        public float RemapOne = 1f;
        /// the value to move to in instant mode
        [Tooltip("the value to move to in instant mode")]
        [MMFEnumCondition("Mode", (int)MMFeedbackBase.Modes.Instant)]
        public float InstantFontSize;
        
        protected override void FillTargets()
        {
            if (TargetTMPText == null)
            {
                return;
            }

            MMF_FeedbackBaseTarget target = new MMF_FeedbackBaseTarget();
            MMPropertyReceiver receiver = new MMPropertyReceiver();
            receiver.TargetObject = TargetTMPText.gameObject;
            receiver.TargetComponent = TargetTMPText;
            receiver.TargetPropertyName = "characterSpacing";
            receiver.RelativeValue = RelativeValues;
            target.Target = receiver;
            target.LevelCurve = CharacterSpacingCurve;
            target.RemapLevelZero = RemapZero;
            target.RemapLevelOne = RemapOne;
            target.InstantLevel = InstantFontSize;

            _targets.Add(target);
        }

    }
}
