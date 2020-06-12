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
        /// ��һƪ Slug
        /// </summary>
        public string PreviousSlug { get; set; }

        /// <summary>
        /// ��һƪ CreateOnUtc
        /// </summary>
        public DateTime PreviousCreateOnUtc { get; set; }

        /// <summary>
        /// ��һƪ
        /// </summary>
        public string Next { get; set; }

        /// <summary>
        /// ��һƪ Slug
        /// </summary>
        public string NextSlug { get; set; }

        /// <summary>
        /// ��һƪCreateOnUtc
        /// </summary>
        public DateTime NextCreateOnUtc { get; set; }

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