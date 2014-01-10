using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISite;

namespace AbstractSite
{
    public class AbstractMainSite
    {
        public event IDelegate.CatalogueEventHandler CataloEventHandler;
        protected virtual void OnCatalogueGO(CatalogueEventArgs e)
        {
            if (CataloEventHandler != null)
            {
                CataloEventHandler(this, e);
            }
        }
        public void InitProgress(int count = 20)
        {
            //符合某一条件
            OnCatalogueGO(new CatalogueEventArgs() { MaxPorgress = count * 10, ProgressNum = 0 });
        }
        public void DoProgress(int progressNum = 10)
        {
            //符合某一条件
            OnCatalogueGO(new CatalogueEventArgs() { ProgressNum = progressNum });
        }
        public event IDelegate.LabelEventHandler LabelEventHandler;

        protected void OnLabelEventHandler(LabelEventArgs labelEventArgs)
        {
            if (LabelEventHandler != null)
            {
                LabelEventHandler(this, labelEventArgs);
            }
        }

        public void SaveIngDish(string dishTypeName, string dishName)
        {
            OnLabelEventHandler(new LabelEventArgs() { LabelText = string.Format("正在保存'{0}'菜系,{1}", dishTypeName, dishName), UpdateType = 1 });
        }
        public void SaveIngPic(string picBox, string picName)
        {
            OnLabelEventHandler(new LabelEventArgs() { LabelText = string.Format("正在保存'{0}'相册,{1}", picBox, picName) });
        }

        public void FinishSaveDish()
        {
            OnLabelEventHandler(new LabelEventArgs() { LabelText = string.Format("完成菜系下载"), UpdateType = 1 });
        }

        public void FinishSavePic()
        {
            OnLabelEventHandler(new LabelEventArgs() { LabelText = string.Format("完成相册下载") });
        }
    }
}
