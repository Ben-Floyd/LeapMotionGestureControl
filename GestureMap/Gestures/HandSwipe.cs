using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeapMotionGestureMap.Gestures
{
    public class HandSwipe : CustomGesture
    {
        public enum SwipeDirection { LEFT, RIGHT };
        private SwipeDirection _diretion;
        private HandSwipe handSwipe;
        private static HandSwipe other = null;

        public HandSwipe(CustomGestureType type, Leap.Frame frame)
            :base(type, frame)
        {
            if (other != null)
            {
                if (other.State.Equals(GestureState.NA))
                {
                    _state = GestureState.START;
                }
                else if (other.State.Equals(GestureState.END))
                {
                    _state = GestureState.NA;
                }
                else
                {
                    _state = GestureState.MIDDLE;
                }
            }

            other = this;

            foreach(Leap.Hand hand in _handsForGesture)
            {
                if (hand.PalmVelocity.x > 0)
                    _diretion = SwipeDirection.RIGHT;
                else
                    _diretion = SwipeDirection.LEFT;
            }
        }

        public static HandSwipe IsHandSwipe(Leap.Frame frame)
        {
            if (frame.IsValid)
            {
                Leap.HandList hands = frame.Hands;

                foreach(Leap.Hand hand in hands)
                {
                    if (Math.Abs(hand.PalmVelocity.x) > 900)
                    {
                        HandSwipe handSwipe = new HandSwipe(CustomGestureType.HAND_SWIPE, frame);
                        return handSwipe;
                    }
                    else if ((other != null))
                    {
                        if(other.State.Equals(GestureState.END) || other.State.Equals(GestureState.NA))
                        {
                            other._state = GestureState.NA;
                            return other;
                        }   
                        else
                        {
                            other._state = GestureState.END;
                            return other;
                        }
                    }
                }
            }

            return null;
        }

        public SwipeDirection Direction
        {
            get { return _diretion; }
        }
    }
}
