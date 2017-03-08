﻿/*
    Copyright (C) 2014-2017 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;

namespace dnSpy.Debugger.ToolWindows.Controls {
	interface IEditValueProvider {
		/// <summary>
		/// Creates a <see cref="IEditValue"/>. This is called by the control when the user has
		/// started the edit operation.
		/// </summary>
		/// <param name="text">Text shown in the control</param>
		/// <returns></returns>
		IEditValue Create(string text);
	}

	interface IEditValue : IDisposable {
		/// <summary>
		/// Gets the UI object (text control)
		/// </summary>
		object UIObject { get; }

		/// <summary>
		/// Raised when the edit is completed (there's new text or the user canceled the edit operation)
		/// </summary>
		event EventHandler<EditCompletedEventArgs> EditCompleted;
	}

	sealed class EditCompletedEventArgs : EventArgs {
		/// <summary>
		/// Gets the new text or null if it was canceled
		/// </summary>
		public string NewText { get; }

		/// <summary>
		/// true if it was canceled by the user by pressing Escape (not because the
		/// edit control lost keyboard focus)
		/// </summary>
		public bool WasCanceled { get; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="newText">New text or null if it was canceled</param>
		/// <param name="wasCanceled">true if user pressed Escape to cancel the edit operation</param>
		public EditCompletedEventArgs(string newText, bool wasCanceled) {
			NewText = newText;
			WasCanceled = wasCanceled;
		}
	}
}