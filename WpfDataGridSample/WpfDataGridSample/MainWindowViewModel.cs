﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace WpfDataGridSample
{
    public class MainWindowViewModel : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {
            Initialize();
        }

        /// <summary>
        /// 初期化処理を行います。
        /// </summary>
        private void Initialize()
        {
            var orders = new ObservableCollection<CorrOrder>();
            orders.Add(new CorrOrder(1, ItemType.Fruits, "りんご", "あああああいいいいいううううう", 3000));
            orders.Add(new CorrOrder(1, ItemType.Fruits, "もも", "かかかかかきききききくくくくく", 2520));
            orders.Add(new CorrOrder(1, ItemType.Vegetables, "トマト", "さささささしししししすすすすす", 1234));
            orders.Add(new CorrOrder(4, ItemType.Vegetables, "いちご", "たたたたたたちちちちちつつつつつ", 98765));
            orders.Add(new CorrOrder(4, ItemType.Vegetables, "ピーマン", "なななななにににににぬぬぬぬぬ", 567));
            orders.Add(new CorrOrder(4, ItemType.Fruits, "なし", "はははははひひひひひふふふふふ", 12));

            var view = (CollectionView)CollectionViewSource.GetDefaultView(orders);
            PropertyGroupDescription gd = new PropertyGroupDescription("ID");
            view.GroupDescriptions.Add(gd);
            this.GridDataCollectionView = view;

        }

        /// <summary>
        /// 表示用データのコレクションを保持します。
        /// </summary>
        private CollectionView _view;

        /// <summary>
        /// 表示用データのコレクションを管理します。
        /// </summary>
        public CollectionView GridDataCollectionView
        {
            get
            {
                return this._view;
            }
            private set
            {
                this._view = value;
                RaisePropertyChanged("GridDataCollectionView");
            }
        }

        #region INotifyPropertyChanged.PropertyChangedの実装

        /// <summary>
        /// プロパティの変更を通知するイベントハンドラを定義します。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// PropertyChangedイベントを発生させます。
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // 重複する呼び出しを検出するには

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: マネージ状態を破棄します (マネージ オブジェクト)。
                }

                // TODO: アンマネージ リソース (アンマネージ オブジェクト) を解放し、下のファイナライザーをオーバーライドします。
                // TODO: 大きなフィールドを null に設定します。

                disposedValue = true;
            }
        }

        // TODO: 上の Dispose(bool disposing) にアンマネージ リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします。
        // ~MainWindowViewModel() {
        //   // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
        //   Dispose(false);
        // }

        // このコードは、破棄可能なパターンを正しく実装できるように追加されました。
        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを上の Dispose(bool disposing) に記述します。
            Dispose(true);
            // TODO: 上のファイナライザーがオーバーライドされる場合は、次の行のコメントを解除してください。
            // GC.SuppressFinalize(this);
        }
        #endregion


    }

    public class CorrOrder
    {
        public int ID { get; set; }

        public ItemType Type { get; set; }

        public string ItemName { get; set; }

        public string Comment { get; set; }

        public int Qty { get; set; }

        public bool Checked { get; set; }

        public CorrOrder(int id, ItemType type, string name, string comment, int qty)
        {
            this.ID = id;
            this.ItemName = name;
            this.Comment = comment;
            this.Qty = qty;
            this.Checked = false;
        }
    }

    public enum ItemType
    {
        Fruits,
        Vegetables
    }

    public class ComboboxItem
    {
        public string Label { get; set; }

        public ItemType Value { get; set; }
    }
}
