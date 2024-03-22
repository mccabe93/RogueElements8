﻿// <copyright file="FloorPathStartStepGeneric.cs" company="Audino">
// Copyright (c) Audino
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using RogueElements;

namespace RogueElements
{
    [Serializable]
    public abstract class FloorPathStartStepGeneric<T> : FloorPathStartStep<T>
        where T : class, IFloorPlanGenContext
    {
        protected FloorPathStartStepGeneric()
        {
            this.RoomComponents = new ComponentCollection();
            this.HallComponents = new ComponentCollection();
        }

        protected FloorPathStartStepGeneric(IRandPicker<RoomGen<T>> genericRooms, IRandPicker<PermissiveRoomGen<T>> genericHalls)
        {
            this.GenericRooms = genericRooms;
            this.GenericHalls = genericHalls;
            this.RoomComponents = new ComponentCollection();
            this.HallComponents = new ComponentCollection();
        }

        /// <summary>
        /// The room types that can be used for the rooms of the layout.
        /// </summary>
        public IRandPicker<RoomGen<T>> GenericRooms { get; set; }

        /// <summary>
        /// Components that the newly added rooms will be labeled with.
        /// </summary>
        public ComponentCollection RoomComponents { get; set; }

        /// <summary>
        /// The room types that can be used for the halls of the layout.
        /// </summary>
        public IRandPicker<PermissiveRoomGen<T>> GenericHalls { get; set; }

        /// <summary>
        /// Components that the newly added halls will be labeled with.
        /// </summary>
        public ComponentCollection HallComponents { get; set; }

        public override void Apply(T map)
        {
            if (!this.GenericRooms.CanPick || !this.GenericHalls.CanPick)
                throw new InvalidOperationException("Can't create a path without rooms or halls.");

            base.Apply(map);
        }
    }
}
