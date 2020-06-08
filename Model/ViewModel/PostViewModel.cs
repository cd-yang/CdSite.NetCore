using System;

namespace CdSite.Model.ViewModel
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// ��һƪ
        /// </summary>
        public string Previous { get; set; }

        /// <summary>
        /// ��һƪid
        /// </summary>
        public int PreviousId { get; set; }

        /// <summary>
        /// ��һƪ
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        /// ��һƪid
        /// </summary>
        public int NextId { get; set; }

        /// <summary>
        /// ��� 
        /// </summary>
        //public string Category { get; set; }

        /// <summary>
        /// ���� 
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public int Traffic { get; set; }

        /// <summary>
        /// �޸�ʱ�� 
        /// </summary>
        public DateTime PubDateUtc { get; set; }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreateOnUtc { get; set; }
    }
}