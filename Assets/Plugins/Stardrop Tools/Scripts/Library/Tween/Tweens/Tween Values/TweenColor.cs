﻿
using UnityEngine;

namespace StardropTools.Tween
{
    public class TweenColor : Tween
    {
        public Color start;
        public Color end;
        public Color lerped;

        protected override void SetEssentials()
        {
            tweenID = start.GetHashCode();
            tweenType = TweenType.Color;
        }

        public TweenColor()
        {
            SetEssentials();
        }

        public TweenColor SetStart(Color start)
        {
            this.start = start;
            return this;
        }

        public TweenColor SetEnd(Color end)
        {
            this.end = end;
            return this;
        }

        public TweenColor SetStartEnd(Color start, Color end)
        {
            this.start = start;
            this.end = end;
            return this;
        }

        protected override void TweenUpdate(float percent)
        {
            lerped = Color.LerpUnclamped(start, end, Ease(percent));
        }

        protected override void Loop()
        {
            ResetRuntime();
            ChangeState(TweenState.Running);
        }

        protected override void PingPong()
        {
            Color temp = start;
            start = end;
            end = temp;

            ResetRuntime();
            ChangeState(TweenState.Running);
        }
    }
}