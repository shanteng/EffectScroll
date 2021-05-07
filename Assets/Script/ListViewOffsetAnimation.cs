using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;

namespace UIWidgets
{
	/// <summary>
	/// ListViewItem.
	/// Item for ListViewBase.
	/// </summary>
	//[RequireComponent(typeof(Graphic))]
	public class ListViewOffsetAnimation : UIBehaviour
	{
		[Title("最大缩放比例", "#FF4F63")]
		public float mMaxScale = 1;
		[Title("最小缩放比例", "#FF4F63")]
		public float mMinScale = 0.8f;
		[Title("缩放和描点距离比例计算系数", "#FF4F63")]
		public float mScaleRate = 0.1f;

		[Title("位移和缩放的节点", "#FF4F63")]
		public RectTransform mOffsetTran;

		[Title("相对锚点", "#FF4F63")]
		public RectTransform mRefTran;

		[Title("位移和锚点距离比例", "#FF4F63")]
		public float mReferenceDelta = 0;

		[Title("统一位移", "#FF4F63")]
		public float mOffset = 0;

		[Title("是否为纵向滑动列表", "#FF4F63")]
		public bool mIsVertical = true;
		private Vector2 mOffsetTranOrignPos;
		private Vector2 mOffsetTranNewPos = Vector2.zero;
		private Vector3 mScale = Vector3.one;
		protected override void Awake()
		{
			this.mOffsetTranOrignPos = this.mOffsetTran.anchoredPosition;
		}

		void LateUpdate()
		{
			UpdateChildAnimationPostion();
		}

		private void UpdateChildAnimationPostion()
		{
			if (this.mOffsetTran == null)
				return;

			float usePos = this.mIsVertical ? this.transform.position.y : this.transform.position.x;
			float targePos = this.mIsVertical ? this.mRefTran.position.y : this.mRefTran.position.x;
			float absOffset = Mathf.Abs(usePos - targePos);
			float offset = absOffset * this.mReferenceDelta + this.mOffset;
			float scale = this.mMaxScale - absOffset * mScaleRate;
			if (scale < this.mMinScale)
				scale = this.mMinScale;
			mScale.x = scale;
			mScale.y = scale;
			mScale.z = scale;

			this.mOffsetTran.localScale = mScale;
			if (this.mIsVertical)
			{
				mOffsetTranNewPos.x = this.mOffsetTranOrignPos.x + offset;
				mOffsetTranNewPos.y = this.mOffsetTranOrignPos.y;
			}
			else
			{
				mOffsetTranNewPos.x = this.mOffsetTranOrignPos.x;
				mOffsetTranNewPos.y = this.mOffsetTranOrignPos.y + offset;
			}
			this.mOffsetTran.anchoredPosition = mOffsetTranNewPos;
		}
	}
}