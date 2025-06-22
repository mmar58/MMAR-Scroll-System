
using MMAR.ScrollSystem.Pagination;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MMAR.ScrollSystem 
{
    public class Controller : MonoBehaviour
    {
        public List<Data> dataList=new();
        public ScrollRect scrollRect;

        public CellView cellPrefab;
        // Scroll Orientation
        public ScrollAlignment scrollAlignment;
        Tween tween;
        #region Pagination Variables
        public PaginationController paginationController;
        bool isPaginationEnabled { get { return paginationController != null; } }

        //[ShowIf("isPaginationEnabled")]
        public int itemsPerPage = 20;
        internal bool updatePagination=false;
        float lastTimePaginationNeedUpdate = -100;
        float delayToSetPagination = .1f;
        #endregion
        [Header("Cell properties")]
        public float cellWidth = 100;
        public float cellHeight = 100;
        #region Variables used for processing
        [HideInInspector]
        public Vector2 scrollRectVelocity=Vector2.zero;
        bool updateVelocity= false;
        #endregion
        RectTransform scrollRectTransform;
        #region Monobehavior life
        public virtual void Awake()
        {
            ResetContentSize();
            // Setting up pagination
            if (isPaginationEnabled)
            {
                SetupPagination();
            }
            tween = GetComponent<Tween>();
            scrollRectTransform = scrollRect.transform as RectTransform;
        }
        public virtual void Update()
        {
            if (isPaginationEnabled && updatePagination)
            {
                updatePagination = false;
                paginationController.UpdatePagination();
                Debug.Log("GameObject " + gameObject.name + " Update pagination");
            }
        }
        #endregion
        public void GetToTheTop()
        {
            if(scrollAlignment==ScrollAlignment.Vertical)
            {
                scrollRect.verticalNormalizedPosition = 1;
            }
            else if (scrollAlignment == ScrollAlignment.Horizontal)
            {
                scrollRect.horizontalNormalizedPosition = 0;
            }
        }
        /// <summary>
        /// Resets the content size as initial
        /// </summary>
        void ResetContentSize()
        {
            switch (scrollAlignment)
            {
                case ScrollAlignment.Vertical:
                    scrollRect.content.sizeDelta = new Vector2(scrollRect.content.sizeDelta.x, 0);
                    break;
                case ScrollAlignment.Horizontal:
                    scrollRect.content.sizeDelta = new Vector2(0, scrollRect.content.sizeDelta.y);
                    break;
            }
        }
        public void SetupPagination()
        {
            // To ignore parpageItem is 0 or less
            if(itemsPerPage <= 0)
            {
                itemsPerPage = 10;
            }
            paginationController.SetupTargetController(this);
        }
        bool IsIndexIsInsideCurrentPage(int index)
        {
            return index >= paginationController.selectedPage * itemsPerPage && index < (paginationController.selectedPage + 1) * itemsPerPage;
        }

        #region Jumping to index functions
        public virtual void JumpToIndex(int index, float duration = .3f,TweenType tweenType=TweenType.Linear)
        {
            if (isPaginationEnabled)
            {
                if (IsIndexIsInsideCurrentPage(index))
                {
                    CalculateAndSendJumpPosition(dataList[index].cellView.transform as RectTransform, duration, tweenType);
                }
                else
                {
                    Debug.Log("The index isn't inside current item range of the page");
                }
            }
            else
            {
                if (dataList.Count > index)
                {
                    CalculateAndSendJumpPosition(dataList[index].cellView.transform as RectTransform, duration, tweenType);
                }
                else
                {
                    Debug.Log("Index " + index + " is out of range");
                }
            }
        }
        protected virtual void CalculateAndSendJumpPosition(RectTransform selectedCell,float duration, TweenType tweenType)
        {
            if (scrollAlignment == ScrollAlignment.Vertical)
            {
                //Calculating the desired position based on total content size and the selected cell position
                var tempPosition = 1 + ((selectedCell.localPosition.y + selectedCell.sizeDelta.y / 2) / scrollRect.content.sizeDelta.y);
                // Also considering the viewport size
                tempPosition -= (scrollRectTransform.sizeDelta.y / scrollRect.content.sizeDelta.y) * (1 - tempPosition);
                // Sending data to tween
                tween.JumpToPosition(new(scrollRect.verticalNormalizedPosition, 0, 0), new(tempPosition, 0, 0), duration, tweenType);
            }
            else if (scrollAlignment == ScrollAlignment.Horizontal)
            {
                //Calculating the desired position based on total content size and the selected cell position
                var tempPosition = (selectedCell.localPosition.x - selectedCell.sizeDelta.x / 2) / scrollRect.content.sizeDelta.x;
                // Also considering the viewport size
                tempPosition += (scrollRectTransform.sizeDelta.x / scrollRect.content.sizeDelta.x) * (tempPosition);
                // Sending data to tween
                tween.JumpToPosition(new(scrollRect.horizontalNormalizedPosition, 0, 0), new(tempPosition, 0, 0), duration, tweenType);
            }
        }
        public void OnTweenUpdate(Vector3 currentPosition)
        {
            if(scrollAlignment == ScrollAlignment.Vertical)
            {
                scrollRect.verticalNormalizedPosition=currentPosition.x;
            }
            else if (scrollAlignment == ScrollAlignment.Horizontal)
            {
                scrollRect.horizontalNormalizedPosition=currentPosition.x;
            }
        }
        public void OnTweenComplete()
        {

        }
        #endregion
        #region Handling Data
        public virtual void AddData(Data data)
        {
            // Getting the index
            var cellViewIndex = dataList.Count;
            // Adding data to list
            dataList.Add(data);

            #region Creating and configuring cell view
            if(!isPaginationEnabled || IsIndexIsInsideCurrentPage(cellViewIndex))
            {
                // Instantiating the cellView
                var curCellView = Instantiate(cellPrefab, scrollRect.content);
                SetCellView(cellViewIndex, curCellView);
            }
            #endregion
            updatePagination = true;
        }

        /// <summary>
        /// Refresh cellviews and update with latest data
        /// </summary>
        public void RefreshView()
        {
            ResetContentSize();
            for (int i = 0; i < dataList.Count; i++)
            {
                if (!isPaginationEnabled || IsIndexIsInsideCurrentPage(i))
                {
                    CellView cellView = null;
                    
                    if(!isPaginationEnabled)
                    {
                        cellView=GetCellView(i);
                    }
                    else
                    {
                        var relativeInt = i - paginationController.selectedPage * itemsPerPage;
                        cellView = GetCellView(relativeInt);
                    }
                    SetCellView(i, cellView);
                }
            }
            #region Destroying extra cellviews
            if (!isPaginationEnabled)
            {
                while (scrollRect.content.childCount > dataList.Count)
                {
                    DestroyImmediate(scrollRect.content.GetChild(scrollRect.content.childCount - 1).gameObject);
                }
            }
            else
            {
                while(scrollRect.content.childCount-1 >= (paginationController.selectedPage + 1) * itemsPerPage)
                {
                    //Debug.Log($"Destroying cellview for index {scrollRect.content.childCount - 1} {Time.time} {paginationController.selectedPage + 1} {itemsPerPage} {(paginationController.selectedPage + 1) * itemsPerPage}");
                    DestroyImmediate(scrollRect.content.GetChild(scrollRect.content.childCount - 1).gameObject);
                }
            }
            #endregion
        }
        /// <summary>
        /// Gets existing or new cell view.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        CellView GetCellView(int index)
        {
            if (index < scrollRect.content.childCount)
            {
                var targetChild = scrollRect.content.GetChild(index);
                Debug.Log($"Reusing cellview for index {index} {Time.time} {targetChild.name}");
                return targetChild.GetComponent<CellView>();
            }
            else
            {
                var targetCellView = Instantiate(cellPrefab, scrollRect.content);
                Debug.Log($"Creating new cellview for index {index} {Time.time} {targetCellView.name}");
                return targetCellView;
            }
        }
        void SetCellView(int index, CellView cellView,bool debug=false)
        {
            cellView.controller = this;
            cellView.SetData(dataList[index]);
            dataList[index].cellView = cellView;
            var cellViewRect = cellView.GetComponent<RectTransform>();
            cellViewRect.sizeDelta = new(GetWidth(index), GetHeight(index));
            switch (scrollAlignment)
            {
                case ScrollAlignment.Vertical:
                    //Setting current cell postion
                    cellViewRect.localPosition = new(GetHorizontalItemPositionX(index, cellViewRect), GetHorizontalItemPositionY(index, cellViewRect));
                    //Updating content size
                    scrollRect.content.sizeDelta += new Vector2(0, cellViewRect.sizeDelta.y);
                    break;

                case ScrollAlignment.Horizontal:
                    //Setting current cell postion
                    cellViewRect.localPosition = new(GetVerticalItemPositionX(index, cellViewRect), GetVerticalItemPositionY(index, cellViewRect));
                    //Updating content size
                    scrollRect.content.sizeDelta += new Vector2(cellViewRect.sizeDelta.x, 0);
                    break;
            }
            if (debug)
            {
                Debug.Log($"Setting cell view for index {index} at position {cellViewRect.localPosition} with size {cellViewRect.sizeDelta}");
            }
        }
        #endregion
        #region Size and position functions
        public virtual float GetHeight(int index)
        {
            return cellHeight;
        }
        public virtual float GetWidth(int index)
        {
            return cellWidth;
        }
        #region Position for horizontal items
        public virtual float GetHorizontalItemPositionX(int index, RectTransform cellRect)
        {
            return cellRect.sizeDelta.x / 2;
        }
        public virtual float GetHorizontalItemPositionY(int index, RectTransform cellRect)
        {
            return -(scrollRect.content.sizeDelta.y + cellRect.sizeDelta.y / 2);
        }
        #endregion
        #region Position for vertical items
        public virtual float GetVerticalItemPositionX(int index,RectTransform cellRect)
        {
            return scrollRect.content.sizeDelta.x + cellRect.sizeDelta.x / 2;
        }
        public virtual float GetVerticalItemPositionY(int index, RectTransform cellRect)
        {
            return -cellRect.sizeDelta.y / 2;
        }
        #endregion
        #endregion
    }
    
    public enum ScrollAlignment
    {
        Vertical = 0, Horizontal=1
    }
}