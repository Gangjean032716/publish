﻿using Application.Dto;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPostServices
    {
        IEnumerable<PostDto> GetAllPost();
        PostDto GetPostById(int id);

        PostDto AddNewPost(CreatePostDto newPost);
        void UpdatePost(UpdatePostDto updatePostDto);
        void DeletePost(int id);

    }
}